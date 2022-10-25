using AutoMapper;
using Core.Application.Auth;
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


namespace Core.Aplication.Auth
{
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

        public async Task<UserDTO> LoginAsync(LoginRequestDTO request)
        {

            var usuario = await _unitOfWork.Users.FirstOrDefaultAsync(new UserByName(request.Name));

            if (usuario == null) {
                throw new UnauthorizedException($"Credenciales incorrectas para el usuario {request.Name}.");
            }
            if (!usuario.IsActive) {
                throw new UnauthorizedException($"La cuenta del usuario {request.Name} no se encuentra activa. Revisa tu bandeja de correo electrónico.");
            }

            var CheckPassword = _passwordHasher.VerifyHashedPassword(usuario, usuario.Password, request.Password);

            if (CheckPassword == PasswordVerificationResult.Success) {
                UserDTO response = _mapper.Map<UserDTO>(usuario);
                response.Token = _unitOfWork.Auth.GenerateJwt(usuario);
                response.Modules = ProcessModules(usuario);
                response.Persons = ProcessPersons(usuario);

                return response;
            }

            throw new UnauthorizedException($"Credenciales incorrectas para el usuario {usuario.Name}.");

        }
        public async Task<UserDTO> RegisterAsync(RegisterRequestDTO request)
        {
            User usuario = _mapper.Map<User>(request);
            usuario.Password = _passwordHasher.HashPassword(usuario, request.Password);


            var existe = await _unitOfWork.Users.FirstOrDefaultAsync(new UserByName(request.Name));

            if (existe == null) {

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

                    usuario.PersonUsers = new List<PersonUser> {
                        new PersonUser() {
                                Person = new Person() {
                                    Name = "", LastName = "", Address = new Address(){}
                                }       
                        } 
                    };


                    var RequireConfirmedAccount = _configuration.GetValue<bool>("SecuritySettings:RequireConfirmedAccount");

                    usuario.IsActive = RequireConfirmedAccount ? false : true ;

                    await _unitOfWork.Users.AddAsync(usuario);
                    await _unitOfWork.SaveAsync();
                    UserDTO dto = _mapper.Map<UserDTO>(usuario);



                    

                    if (RequireConfirmedAccount)
                    {
                        //Devuelve el template de activación de cuenta
                        var template = await _unitOfWork.MailTemplates.FirstOrDefaultAsync(new TemplateById(1));
                        var activateUrl = _configuration.GetValue<string>("SecuritySettings:ActivationLinkUrl");

                        var activationId = await SaveMailActivation(usuario.UserId);
                        var data = new { Name = request.Name, ActivateUrl= activateUrl + activationId };
                        await SendConfirmationEmail(request.Email, request.Name, _jsonSerializer.Serialize(data), template);

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

        private List<ModuleDTO> ProcessModules(User usuario)
        {
            try {
                List<ModuleDTO> _modules = new List<ModuleDTO>();
                List<ModuleUser> filterd = usuario.ModuleUsers.GroupBy(g => g.ModuleId).Select(g => g.First()).ToList();

                foreach (var mu in filterd) {
                    ModuleDTO dto = _mapper.Map<ModuleDTO>(mu.Module);
                    _modules.Add(dto);
                }

                foreach (var m in _modules) {
                    var permissions = usuario.ModuleUsers.Where(x => x.ModuleId == m.ModuleId).Select(x => x.Permission).ToList();

                    m.Permissions = new List<PermissionDTO>();
                    foreach (var p in permissions) {
                        PermissionDTO dto = _mapper.Map<PermissionDTO>(p);
                        m.Permissions.Add(dto);
                    }
                }


                var lookup = _modules.ToLookup(x => x.ParentId);
                Func<int?, List<ModuleDTO>> build = null;

                build = pid => lookup[pid].Select(x => new ModuleDTO()
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

                List<ModuleDTO> trees = build(null);

                return trees;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }

        }
        private List<PersonResponse> ProcessPersons(User usuario)
        {
            try {
                List<PersonResponse> _persons = new List<PersonResponse>();

                foreach (var p in usuario.PersonUsers) {
                    PersonResponse dto = _mapper.Map<PersonResponse>(p.Person);
                    _persons.Add(dto);
                }
                return _persons;
            }
            catch (Exception ex) {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }
        private async Task SendConfirmationEmail(string Email, string Name, string Data, Template template)
        {
            var mailRequest = new EmailRequest();
            mailRequest.To = new List<RecipientCustom> { new RecipientCustom() { Email = Email, Name = Name, Data = Data}};
            mailRequest.Subject = template.Name;
            mailRequest.HTMLTemplate = template.Url;
            mailRequest.IsUrlTemplate = template.IsHtml;
            mailRequest.IsCustomized = template.IsCustom;

            var mailResponse = await _notification.SendMail(mailRequest);
        }
        private async Task<string> SaveMailActivation(int UserId)
        {
            int expirationHours = _configuration.GetValue<int>("SecuritySettings:ActivationLinkExpiration");
            Activation activation = new Activation()
            {
                IsActive = true,
                UserId = UserId,
                Expiration = DateTime.Now.AddHours(expirationHours)
            };

            await _unitOfWork.MailActivations.AddAsync(activation);

            return activation.ActivationId.ToString();
        }


    }
}

