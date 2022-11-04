using AutoMapper;
using Core.Application.Admin;
using Core.Application.Common.Especifications;
using Core.Application.Common.Models;
using Core.Application.Profile;
using Core.Common.Exceptions;
using Core.Domain.Entities.Mail;
using Core.Domain.Interfaces.Services;
using Core.Entities.Auth;
using Core.Entities.Persons;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace Core.Application.Auth;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IMapper _mapper;
    private readonly ILogger<AuthService> _logger;
    private readonly INotificationService _notification;
    private readonly ISerializerService _jsonSerializer;

    public AuthService( IUnitOfWork unitOfWork, IPasswordHasher<User> passwordHasher, IMapper mapper, ILogger<AuthService> logger,
                        INotificationService notification, ISerializerService jsonSerializer, IConfiguration configuration)
    {
        _configuration = configuration;
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
        _mapper = mapper;
        _logger = logger;
        _notification = notification;
        _jsonSerializer = jsonSerializer;
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {

        var usuario = await _unitOfWork.Users.FirstOrDefaultAsync(new UserByName(request.Name));

        if (usuario == null) {
            throw new UnauthorizedException($"Credenciales incorrectas para el usuario {request.Name}.");
        }
        if (!usuario.IsActive && !usuario.EmailConfirmed) {
            throw new UnauthorizedException($"La cuenta del usuario {request.Name} no se encuentra activa. Revisa tu bandeja de correo electrónico.");
        }
        if (!usuario.IsActive && usuario.EmailConfirmed)
        {
            throw new UnauthorizedException($"La cuenta del usuario {request.Name} fue suspendida. Comunícate con el administrador.");
        }

        var CheckPassword = _passwordHasher.VerifyHashedPassword(usuario, usuario.Password, request.Password);

        if (CheckPassword == PasswordVerificationResult.Success) {
            LoginResponse response = _mapper.Map<LoginResponse>(usuario);
            response.Token = _unitOfWork.Auth.GenerateJwt(usuario);
            response.Modules = ProcessModules(usuario);
            response.Profile = ProcessPersons(usuario);

            return response;
        }

        throw new UnauthorizedException($"Credenciales incorrectas para el usuario {usuario.Name}.");

    }
    public async Task<LoginResponse> RegisterAsync(RegisterRequest request)
    {
        var selfRegister = _configuration.GetValue<bool>("SecuritySettings:AllowSelfRegister");

        if (!selfRegister) throw new UnauthorizedException("Registro de usuarios no permitido en esta aplicación");


        User usuario = _mapper.Map<User>(request);
        usuario.Password = _passwordHasher.HashPassword(usuario, request.Password);


        var existe = await _unitOfWork.Users.FirstOrDefaultAsync(new UserByName(request.Name));

        if (existe == null || existe?.IsActive == false) {

            try {
                var role = await _unitOfWork.Roles.FirstOrDefaultAsync(new RolebyId(request.RoleId));
                if (role != null)
                {
                    usuario.ModuleUsers = new List<ModuleUser>();
                    foreach (var mr in role.ModuleRoles)
                    {
                        usuario.ModuleUsers.Add(new ModuleUser() { ModuleId = mr.ModuleId, PermissionId = mr.PermissionId, Module = mr.Module });
                    }
                }

                var photo = _configuration.GetValue<string>("SecuritySettings:DefaultUserPhoto");

                usuario.PersonUsers = new List<PersonUser> {
                    new PersonUser() {
                        Principal = true,
                        Person = new Person() {Name = "", LastName = "", Photo = photo, Address = new Address(){} }       
                    } 
                };


                var RequireConfirmedAccount = _configuration.GetValue<bool>("SecuritySettings:RequireConfirmedAccount");

                usuario.IsActive = RequireConfirmedAccount ? false : true ;

                await _unitOfWork.Users.AddAsync(usuario);
                await _unitOfWork.SaveAsync();
                LoginResponse dto = _mapper.Map<LoginResponse>(usuario);



                if (RequireConfirmedAccount)  {
                    int expirationHours = _configuration.GetValue<int>("SecuritySettings:ActivationLinkExpiration");
                    var activationId = await SaveMailActivation(usuario.UserId, expirationHours);
                    await SendConfirmationEmail(request.Email, request.Name, activationId);
                }
                else dto.Token = _unitOfWork.Auth.GenerateJwt(usuario);


                dto.Modules = ProcessModules(usuario);

                return dto;
            }
            catch (Exception ex) {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
        else {
            throw new BadRequestException($"El usuario {request.Name} ya se encuentra registrado.");
        }
    }

    public async Task ActivateAccountAsync(Guid activationId)
    {
        var code = await _unitOfWork.MailActivations.FirstOrDefaultAsync(new ActivationById(activationId));

        if (code == null) throw new NotFoundException($"El código de activación {activationId} no fue encontrado.");
        if (code.Expiration < DateTime.Now) throw new BadRequestException($"El código de activación {activationId} ha expirado.");
        if (code.IsActive == false) throw new BadRequestException($"El código de activación {activationId} no es válido.");


        var user = await _unitOfWork.Users.FirstOrDefaultAsync(new UserById(code.UserId));
        if (user == null) throw new NotFoundException($"El usuario asociado al código de activación {activationId} no fue encontrado.");
        if (user.IsActive == true) throw new BadRequestException($"El usuario ya ha sido activdo previamente.");


        user.IsActive = true;
        user.EmailConfirmed = true;
        await _unitOfWork.Users.UpdateAsync(user);

        code.IsActive = false;
        await _unitOfWork.MailActivations.UpdateAsync(code);

    }
    public async Task SendActivationCodeAsync(string email)
    {
        var result = await _unitOfWork.Users.FirstOrDefaultAsync(new UserByName(email));

        if (result == null) throw new NotFoundException($"El usuario con email {email} no fue encontrado.");
        if (result.IsActive) throw new BadRequestException($"La cuenta del usuario {email} ya ha sido activada previamente");

        int expirationHours = _configuration.GetValue<int>("SecuritySettings:ActivationLinkExpiration");
        var activationId = await SaveMailActivation(result.UserId, expirationHours);
        await SendConfirmationEmail(email, email, activationId);

    }
    public async Task SetNewPasswordAsync(NewPasswordRequest request)
    {

        if (!Guid.TryParse(request.ActivationId, out var guid)) throw new BadRequestException("El código proporcionado no tiene un formato válido");


        var code = await _unitOfWork.MailActivations.FirstOrDefaultAsync(new ActivationById(guid));

        if (code == null) throw new NotFoundException($"El código de activación {guid} no fue encontrado.");
        if (code.Expiration < DateTime.Now) throw new BadRequestException($"El código de activación {guid} ha expirado.");
        if (code.IsActive == false) throw new BadRequestException($"El código de activación {guid} no es válido.");

        var user = await _unitOfWork.Users.FirstOrDefaultAsync(new UserById(code.UserId));
        if (user == null) throw new NotFoundException($"El usuario asociado al código de activación {guid} no fue encontrado.");
        if (!user.IsActive) throw new BadRequestException($"El usuario asociado al código de activación no se encuentra activo.");

        //var CheckPassword = _passwordHasher.VerifyHashedPassword(user, user.Password, request.OldPassword);
        //if (CheckPassword == PasswordVerificationResult.Failed) throw new UnauthorizedException($"La contraseña actual del usuario es incorrecta");

        user.Password = _passwordHasher.HashPassword(user, request.NewPassword);
        await _unitOfWork.Users.UpdateAsync(user);

        code.IsActive = false;
        await _unitOfWork.MailActivations.UpdateAsync(code);

    }
    public async Task SendRecoveryCodeAsync(string email)
    {
        var user = await _unitOfWork.Users.FirstOrDefaultAsync(new UserByName(email));
        if (user == null) throw new NotFoundException($"El usuario con email {email} no fue encontrado.");
        if (!user.IsActive) throw new BadRequestException($"La cuenta de usuario {email} no se encuentra activa.");

        int expirationHours = _configuration.GetValue<int>("SecuritySettings:RecoveryLinkExpiration");
        var activationId = await SaveMailActivation(user.UserId, expirationHours);
        await SendRecoveryEmail(email, email, activationId, expirationHours);

    }



    private List<ModuleResponse> ProcessModules(User usuario)
    {
        try {
            List<ModuleResponse> _modules = new List<ModuleResponse>();
            List<ModuleUser> filterd = usuario.ModuleUsers.GroupBy(g => g.ModuleId).Select(g => g.First()).ToList();

            foreach (var mu in filterd) {
                ModuleResponse dto = _mapper.Map<ModuleResponse>(mu.Module);
                _modules.Add(dto);
            }

            foreach (var m in _modules) {
                var permissions = usuario.ModuleUsers.Where(x => x.ModuleId == m.ModuleId).Select(x => x.Permission).ToList();

                m.Permissions = new List<PermissionResponse>();
                foreach (var p in permissions) {
                    PermissionResponse dto = _mapper.Map<PermissionResponse>(p);
                    m.Permissions.Add(dto);
                }
            }


            var lookup = _modules.ToLookup(x => x.ParentId);
            Func<int?, List<ModuleResponse>> build = null;

            build = pid => lookup[pid].Select(x => new ModuleResponse()
            {
                ModuleId = x.ModuleId,
                Name = x.Name,
                Title = x.Title,
                Subtitle = x.Subtitle,
                Route = x.Route,
                CssClass = x.CssClass,
                Description = x.Description,
                IsActive = x.IsActive,
                IsVisible = x.IsVisible,
                DisplayOrder = x.DisplayOrder,
                ParentId = x.ParentId,
                Permissions = x.Permissions,
                Children = build(x.ModuleId)
            }).ToList();

            List<ModuleResponse> trees = build(null);

            return trees;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return null;
        }

    }
    private PersonResponse ProcessPersons(User usuario)
    {
        try {
            var principal = usuario.PersonUsers.Where(x => x.Principal == true).FirstOrDefault();
            var dto = _mapper.Map<PersonResponse>(principal.Person);
            return dto;
        }
        catch (Exception ex) {
            _logger.LogError(ex, ex.Message);
            return null;
        }
    }
    private async Task<string> SaveMailActivation(int userId, int expirationHours)
    {
        Activation activation = new Activation()
        {
            IsActive = true,
            UserId = userId,
            Expiration = DateTime.Now.AddHours(expirationHours)
        };

        await _unitOfWork.MailActivations.AddAsync(activation);

        return activation.ActivationId.ToString();
    }
    private async Task SendConfirmationEmail(string email, string name, string activationId)
    {
        //Devuelve el template html de activación de cuenta
        var template = await _unitOfWork.MailTemplates.FirstOrDefaultAsync(new TemplateById(1));
        var activateUrl = _configuration.GetValue<string>("SecuritySettings:ActivationLinkUrl") + activationId;

        var data = new { Name = name, ActivateUrl = activateUrl};


        var mailRequest = new EmailRequest();
        mailRequest.To = new List<RecipientCustom> { new RecipientCustom() { Email = email, Name = name, Data = _jsonSerializer.Serialize(data) } };
        mailRequest.Subject = template.Name;
        mailRequest.HTMLTemplate = template.Url;
        mailRequest.IsUrlTemplate = template.IsHtml;
        mailRequest.IsCustomized = template.IsCustom;

        var mailResponse = await _notification.SendMail(mailRequest);
    }
    private async Task SendRecoveryEmail(string email, string name, string activationId, int expirationHours)
    {
        //Devuelve el template html de rescuperación de contraseña
        var template = await _unitOfWork.MailTemplates.FirstOrDefaultAsync(new TemplateById(2));
        var recoveryUrl = _configuration.GetValue<string>("SecuritySettings:RecoveryLinkUrl") + activationId;

        var data = new { Name = name, RecoveryUrl = recoveryUrl, Expiration= expirationHours.ToString() };


        var mailRequest = new EmailRequest();
        mailRequest.To = new List<RecipientCustom> { new RecipientCustom() { Email = email, Name = name, Data = _jsonSerializer.Serialize(data) } };
        mailRequest.Subject = template.Name;
        mailRequest.HTMLTemplate = template.Url;
        mailRequest.IsUrlTemplate = template.IsHtml;
        mailRequest.IsCustomized = template.IsCustom;

        var mailResponse = await _notification.SendMail(mailRequest);
    }



}

