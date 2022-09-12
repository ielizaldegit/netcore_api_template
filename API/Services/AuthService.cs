using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using API.DTOs;
using API.Helpers;
using API.Helpers.Errors;
using AutoMapper;
using Core.Common.Exceptions;
using Core.Entities.Auth;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


namespace API.Services
{
    public class AuthService : IAuthService
    {
        private readonly JWT _jwt;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IMapper _mapper;

        public AuthService(IUnitOfWork unitOfWork, IOptions<JWT> jwt,IPasswordHasher<User> passwordHasher,IMapper mapper) {
            _jwt = jwt.Value;
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }



        public async Task<UserDTO> LoginAsync(LoginRequestDTO request)
        {

            var usuario = await _unitOfWork.Users.GetByUsernameAsync(request.Name);

            if (usuario == null)
            {
                throw new Exception($"Credenciales incorrectas para el usuario {request.Name}.");
            }

            var CheckPassword = _passwordHasher.VerifyHashedPassword(usuario, usuario.Password, request.Password);

            if (CheckPassword == PasswordVerificationResult.Success)
            {
                UserDTO response = _mapper.Map<UserDTO>(usuario);
                //JwtSecurityToken jwtSecurityToken = CreateJwtToken(usuario);
                response.Token = _unitOfWork.Users.GenerateJwt(usuario); //new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

                response.Modules = ProcessModules(usuario);
                response.Persons = ProcessPersons(usuario);


                return response;
            }

            //return null;
            throw new Exception($"Credenciales incorrectas para el usuario {usuario.Name}.");

        }
        public async Task<UserDTO> RegisterAsync(RegisterRequestDTO request)
        {
            User usuario = _mapper.Map<User>(request);
            usuario.Password = _passwordHasher.HashPassword(usuario, request.Password);

            var usuarioExiste = _unitOfWork.Users.Find(u => u.Name.ToLower() == request.Name.ToLower()).FirstOrDefault();

            if (usuarioExiste == null)
            {
                try
                {
                    //Obtener modulos del role para el usuario
                    var role = await _unitOfWork.Roles.GetByIdAsync(request.RoleId);
                    if (role != null)
                    {
                        usuario.ModuleUsers = new List<ModuleUser>();
                        foreach (var mr in role.ModuleRoles)
                        {
                            usuario.ModuleUsers.Add(new ModuleUser() { ModuleId = mr.ModuleId, PermissionId = mr.PermissionId, Module = mr.Module });
                        }
                    }

                    _unitOfWork.Users.Add(usuario);
                    //await _unitOfWork.SaveAsync(request.CreatedBy ?? 0);
                    await _unitOfWork.SaveAsync();


                    UserDTO dto = _mapper.Map<UserDTO>(usuario);

                    //JwtSecurityToken jwtSecurityToken = CreateJwtToken(usuario);
                    dto.Token = _unitOfWork.Users.GenerateJwt(usuario);// new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                    dto.Modules = ProcessModules(usuario);

                    return dto;
                }
                catch (Exception ex)
                {
                    throw new InternalServerException("El usuario no pudo ser registrado correctamente");
                }
            }
            else
            {
                throw new InternalServerException($"El usuario {request.Name} ya se encuentra registrado.");
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
                return null;
            }

        }



        //private JwtSecurityToken CreateJwtToken(User usuario)
        //{
        //    var claims = new[]
        //    {
        //        new Claim(JwtRegisteredClaimNames.NameId, usuario.UserId.ToString()),
        //        new Claim(JwtRegisteredClaimNames.Name, usuario.Name),
        //        new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
        //        //new Claim(ClaimTypes.NameIdentifier, usuario.UserId.ToString()),
        //        new Claim("role" , usuario.Role.Name),
        //        new Claim("role_id", usuario.Role.RoleId.ToString())
        //    };


        //    var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
        //    var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
        //    var jwtSecurityToken = new JwtSecurityToken(
        //        issuer: _jwt.Issuer,
        //        audience: _jwt.Audience,
        //        claims: claims,
        //        expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
        //        signingCredentials: signingCredentials);
        //    return jwtSecurityToken;
        //}



    }
}

