using AutoMapper;
using Core.Application.Auth;
using Core.Common.Exceptions;
using Core.DTOs;
using Core.Entities.Auth;
using Core.Interfaces;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Core.Aplication.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthService> _logger;

        public AuthService(IUnitOfWork unitOfWork, IPasswordHasher<User> passwordHasher, IMapper mapper, ILogger<AuthService> logger)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserDTO> LoginAsync(LoginRequestDTO request)
        {

            var usuario = await _unitOfWork.Users.FirstOrDefaultAsync(new UserByName(request.Name));

            if (usuario == null)
            {
                throw new UnauthorizedException($"Credenciales incorrectas para el usuario {request.Name}.");
            }

            var CheckPassword = _passwordHasher.VerifyHashedPassword(usuario, usuario.Password, request.Password);

            if (CheckPassword == PasswordVerificationResult.Success)
            {
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
            usuario.IsActive = true;

            var existe = await _unitOfWork.Users.FirstOrDefaultAsync(new UserByName(request.Name));

            if (existe == null)
            {
                try
                {
                    var role = await _unitOfWork.Roles.FirstOrDefaultAsync(new RolebyId(request.RoleId));
                    if (role != null)
                    {
                        usuario.ModuleUsers = new List<ModuleUser>();
                        foreach (var mr in role.ModuleRoles)
                        {
                            usuario.ModuleUsers.Add(new ModuleUser() { ModuleId = mr.ModuleId, PermissionId = mr.PermissionId, Module = mr.Module });
                        }
                    }
                    await _unitOfWork.Users.AddAsync(usuario);
                    await _unitOfWork.SaveAsync();

                    UserDTO dto = _mapper.Map<UserDTO>(usuario);
                    dto.Token = _unitOfWork.Auth.GenerateJwt(usuario);
                    dto.Modules = ProcessModules(usuario);

                    return dto;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                    throw;
                }
            }
            else
            {
                throw new BadRequestException($"El usuario {request.Name} ya se encuentra registrado.");
            }
        }

        private List<ModuleDTO> ProcessModules(User usuario)
        {
            //Procesar modulos de usuario

            try
            {
                List<ModuleDTO> _modules = new List<ModuleDTO>();
                List<ModuleUser> filterd = usuario.ModuleUsers.GroupBy(g => g.ModuleId).Select(g => g.First()).ToList();



                foreach (var mu in filterd)
                {
                    ModuleDTO dto = _mapper.Map<ModuleDTO>(mu.Module);
                    _modules.Add(dto);
                }

                foreach (var m in _modules)
                {
                    var permissions = usuario.ModuleUsers.Where(x => x.ModuleId == m.ModuleId).Select(x => x.Permission).ToList();

                    m.Permissions = new List<PermissionDTO>();
                    foreach (var p in permissions)
                    {
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
        private List<PersonDTO> ProcessPersons(User usuario)
        {
            try
            {
                List<PersonDTO> _persons = new List<PersonDTO>();

                foreach (var p in usuario.PersonUsers)
                {
                    PersonDTO dto = _mapper.Map<PersonDTO>(p.Person);
                    _persons.Add(dto);
                }


                return _persons;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }

        }



    }
}

