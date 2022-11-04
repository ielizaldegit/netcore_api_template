using System.Text;
using AutoMapper;
using Core.Application.Auth;
using Core.Application.Common.Especifications;
using Core.Application.Common.Models;
using Core.Common.Exceptions;
using Core.Domain.Interfaces.Services;
using Core.Entities.Auth;
using Core.Entities.Persons;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Core.Application.Admin;

public class AdminService: IAdminService
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<AuthService> _logger;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IConfiguration _configuration;
    private readonly INotificationService _notification;
    private readonly ISerializerService _jsonSerializer;

    public AdminService(IUnitOfWork unitOfWork, IMapper mapper, IPasswordHasher<User> passwordHasher, ILogger<AuthService> logger, IConfiguration configuration,
                        INotificationService notification, ISerializerService jsonSerializer) {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
        _passwordHasher = passwordHasher;
        _configuration = configuration;
        _notification = notification;
        _jsonSerializer = jsonSerializer;
    }


    #region Users
    public async Task<List<UserResponse>> GetAllUsersAsync()
    {
        var result = await _unitOfWork.Users.ListAsync(new SearchAllUsers());
        return _mapper.Map<List<UserResponse>>(result);
    }
    public async Task<UserResponse> RegisterAsync(CreateUserRequest request)
    {
        User usuario = _mapper.Map<User>(request);
        string password = CreateTemporaryPassword(10, true);
        usuario.Password = _passwordHasher.HashPassword(usuario, password);


        var existe = await _unitOfWork.Users.FirstOrDefaultAsync(new UserByName(request.Name));

        if (existe == null || existe?.IsActive == false)
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

                var photo = _configuration.GetValue<string>("SecuritySettings:DefaultUserPhoto");

                usuario.PersonUsers = new List<PersonUser> {
                    new PersonUser() {
                        Principal = true,
                        Person = new Person() {Name = "", LastName = "", Photo = photo, Address = new Address(){} }
                    }
                };

                usuario.IsActive =  true;
                usuario.IsTemporaryPassword = true;

                await _unitOfWork.Users.AddAsync(usuario);
                UserResponse dto = _mapper.Map<UserResponse>(usuario);

                await SendWelcomeEmail(request.Email, request.Name, password);

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
    #endregion

    #region Permission
    public async Task<List<PermissionResponse>> GetAllPermissionsAsync()
    {
        var result = await _unitOfWork.Permissions.ListAsync(new SearchAllPermissions());
        return _mapper.Map<List<PermissionResponse>>(result);
    }
    public async Task<List<PermissionResponse>> GetParentPermissionsAsync()
    {
        var result = await _unitOfWork.Permissions.ListAsync(new GetParentPermissions());
        return _mapper.Map<List<PermissionResponse>>(result);
    }
    public async Task<PermissionResponse> AddPermissionsAsync(CreatePermissionRequest request)
    {
        var existe = await _unitOfWork.Permissions.FirstOrDefaultAsync(new GetPermissionsByName(request.Name));
        if (existe != null) throw new BadRequestException($"Existe un permiso con el nombre '{request.Name}' previamente registrado");

        Permission permission = _mapper.Map<Permission>(request);
        permission.IsActive = true;
        await _unitOfWork.Permissions.AddAsync(permission);

        return _mapper.Map<PermissionResponse>(permission);
    }
    public async Task<PermissionResponse> UpdatePermissionsAsync(UpdatePermissionRequest request)
    {
        var permission = await _unitOfWork.Permissions.FirstOrDefaultAsync(new GetPermissionsById(request.PermissionId));
        if (permission == null) throw new NotFoundException($"No fue encontrado un permiso con el id '{request.PermissionId}'.");

        _mapper.Map(request, permission);
        await _unitOfWork.Permissions.UpdateAsync(permission);

        return _mapper.Map<PermissionResponse>(permission);

    }
    public async Task DeletePermissionsAsync(int id)
    {
        var permission = await _unitOfWork.Permissions.FirstOrDefaultAsync(new GetPermissionsById(id));
        if (permission == null) throw new NotFoundException($"No fue encontrado un permiso con el id '{id}'.");

        permission.IsActive = false;
        await _unitOfWork.Permissions.UpdateAsync(permission);
    }
    #endregion

    #region Modules
    public async Task<List<ModuleResponse>> GetAllModulesAsync()
    {
        var result = await _unitOfWork.Modules.ListAsync(new SearchAllModules());
        return _mapper.Map<List<ModuleResponse>>(result);
    }
    public async Task<ModuleResponse> AddModulesAsync(CreateModuleRequest request)
    {
        var existe = await _unitOfWork.Modules.FirstOrDefaultAsync(new GetModuleByName(request.Name));
        if (existe != null) throw new BadRequestException($"Existe un módulo con el nombre '{request.Name}' previamente registrado");

        Module module = _mapper.Map<Module>(request);
        module.IsActive = true;
        await _unitOfWork.Modules.AddAsync(module);

        return _mapper.Map<ModuleResponse>(module);
    }
    public async Task<ModuleResponse> UpdateModulesAsync(UpdateModuleRequest request)
    {
        var module = await _unitOfWork.Modules.FirstOrDefaultAsync(new GetModulesById(request.ModuleId));
        if (module == null) throw new NotFoundException($"No fue encontrado un módulo con el id '{request.ModuleId}'.");

        _mapper.Map(request, module);
        await _unitOfWork.Modules.UpdateAsync(module);

        return _mapper.Map<ModuleResponse>(module);

    }
    public async Task DeleteModuleAsync(int id)
    {
        var module = await _unitOfWork.Modules.FirstOrDefaultAsync(new GetModulesById(id));
        if (module == null) throw new NotFoundException($"No fue encontrado un módulo con el id '{id}'.");

        module.IsActive = false;
        await _unitOfWork.Modules.UpdateAsync(module);
    }
    public async Task AddModulePermissionAsync(int ModuleId, int PermissionId)
    {
        var module = await _unitOfWork.Modules.FirstOrDefaultAsync(new GetModulesById(ModuleId));
        if (module == null) throw new NotFoundException($"No fue encontrado un módulo con el id '{ModuleId}'.");

        var permission = await _unitOfWork.Permissions.FirstOrDefaultAsync(new GetPermissionsById(PermissionId));
        if (permission == null) throw new NotFoundException($"No fue encontrado un permiso con el id '{PermissionId}'.");

        if (module.ModulePermissions == null)
            module.ModulePermissions = new List<ModulePermission>() { new ModulePermission() { PermissionId = PermissionId} };
        else
        {
            var existe = module.ModulePermissions.Where(u => u.PermissionId == PermissionId).SingleOrDefault();
            if (existe != null) throw new BadRequestException($"El Permiso '{permission.Name}' ya esta asignado al módulo  '{module.Name}'.");
            module.ModulePermissions.Add(new ModulePermission() { PermissionId = PermissionId });
        }
           
        await _unitOfWork.Modules.UpdateAsync(module);

    }
    public async Task DeleteModulePermissionAsync(int ModuleId, int PermissionId)
    {
        var module = await _unitOfWork.Modules.FirstOrDefaultAsync(new GetModulesById(ModuleId));
        if (module == null) throw new NotFoundException($"No fue encontrado un módulo con el id '{ModuleId}'.");

        var permission = await _unitOfWork.Permissions.FirstOrDefaultAsync(new GetPermissionsById(PermissionId));
        if (permission == null) throw new NotFoundException($"No fue encontrado un permiso con el id '{PermissionId}'.");

        var permissionToRemove = module.ModulePermissions.Where(u => u.PermissionId == PermissionId).SingleOrDefault();
        if (permissionToRemove == null) throw new NotFoundException($"No fue encontrado un permiso '{permission.Name}' dentro del módulo '{module.Name}'.");

        module.ModulePermissions.Remove(permissionToRemove);

        await _unitOfWork.Modules.UpdateAsync(module);

    }
    public async Task UpdateModulePermissionAsync(int ModuleId, int[] PermissionIds)
    {
        var module = await _unitOfWork.Modules.FirstOrDefaultAsync(new GetModulesById(ModuleId));
        if (module == null) throw new NotFoundException($"No fue encontrado un módulo con el id '{ModuleId}'.");

        var modulePermissions = new List<ModulePermission>();

        foreach (var id in PermissionIds)
        {
            var permission = await _unitOfWork.Permissions.FirstOrDefaultAsync(new GetPermissionsById(id));
            if (permission == null) throw new NotFoundException($"No fue encontrado un permiso con el id '{id}'.");

            modulePermissions.Add(new ModulePermission() { PermissionId = id });
        }

        module.ModulePermissions = modulePermissions;

        await _unitOfWork.Modules.UpdateAsync(module);

    }
    #endregion

    #region Roles
    public async Task<List<RoleResponse>> GetAllRolesAsync()
    {
        var result = await _unitOfWork.Roles.ListAsync(new SearchAllRoles());
        return _mapper.Map<List<RoleResponse>>(result);
    }
    public async Task<RoleResponse> AddRolesAsync(CreateRoleRequest request)
    {
        var existe = await _unitOfWork.Roles.FirstOrDefaultAsync(new GetRoleByName(request.Name));
        if (existe != null) throw new BadRequestException($"Existe un rol con el nombre '{request.Name}' previamente registrado");

        Role role = _mapper.Map<Role>(request);
        role.IsActive = true;
        await _unitOfWork.Roles.AddAsync(role);

        return _mapper.Map<RoleResponse>(role);
    }
    public async Task<RoleResponse> UpdateRolesAsync(UpdateRoleRequest request)
    {
        var role = await _unitOfWork.Roles.FirstOrDefaultAsync(new GetRoleById(request.RoleId));
        if (role == null) throw new NotFoundException($"No fue encontrado un rol con el id '{request.RoleId}'.");

        _mapper.Map(request, role);
        await _unitOfWork.Roles.UpdateAsync(role);

        return _mapper.Map<RoleResponse>(role);
    }
    public async Task DeleteRoleAsync(int id)
    {
        var role = await _unitOfWork.Roles.FirstOrDefaultAsync(new GetRoleById(id));
        if (role == null) throw new NotFoundException($"No fue encontrado un role con el id '{id}'.");

        role.IsActive = false;
        await _unitOfWork.Roles.UpdateAsync(role);
    }
    public async Task AddRoleModuleAsync(int RoleId, int ModuleId, int PermissionId)
    {
        var role = await _unitOfWork.Roles.FirstOrDefaultAsync(new GetRoleById(RoleId));
        if (role == null) throw new NotFoundException($"No fue encontrado un rol con el id '{RoleId}'.");

        var module = await _unitOfWork.Modules.FirstOrDefaultAsync(new GetModulesById(ModuleId));
        if (module == null) throw new NotFoundException($"No fue encontrado un módulo con el id '{ModuleId}'.");

        var permission = module.ModulePermissions.Where(m=> m.PermissionId == PermissionId).SingleOrDefault().Permission;
        //var permission = await _unitOfWork.Permissions.FirstOrDefaultAsync(new GetPermissionsById(PermissionId));
        if (permission == null) throw new NotFoundException($"El permiso con id'{PermissionId}' no corresponde al módulo {module.Name}.");


        if (role.ModuleRoles == null)
            role.ModuleRoles = new List<ModuleRole>() { new ModuleRole() {  ModuleId = ModuleId, PermissionId = PermissionId } };
        else
        {
            var existe = role.ModuleRoles.Where(u => u.PermissionId == PermissionId && u.ModuleId == ModuleId).SingleOrDefault();
            if (existe != null) throw new BadRequestException($"El Modulo '{module.Name}' con permiso { permission.Name} ya esta asignado al rol  '{role.Name}'.");
            role.ModuleRoles.Add(new ModuleRole() { PermissionId = PermissionId, ModuleId = ModuleId });
        }

        await _unitOfWork.Roles.UpdateAsync(role);
    }
    public async Task DeleteRoleModuleAsync(int RoleId, int ModuleId, int PermissionId)
    {
        var role = await _unitOfWork.Roles.FirstOrDefaultAsync(new GetRoleById(RoleId));
        if (role == null) throw new NotFoundException($"No fue encontrado un rol con el id '{RoleId}'.");

        var module = await _unitOfWork.Modules.FirstOrDefaultAsync(new GetModulesById(ModuleId));
        if (module == null) throw new NotFoundException($"No fue encontrado un módulo con el id '{ModuleId}'.");

        var permission = module.ModulePermissions.Where(m => m.PermissionId == PermissionId).SingleOrDefault().Permission;
        if (permission == null) throw new NotFoundException($"El permiso con id'{PermissionId}' no corresponde al módulo {module.Name}.");

        var moduleToRemove = role.ModuleRoles.Where(u => u.PermissionId == PermissionId && u.ModuleId == ModuleId).SingleOrDefault();
        if (moduleToRemove == null) throw new NotFoundException($"No fue encontrado el módulo '{module.Name}' con permison {permission.Name} dentro del rol '{role.Name}'.");

        role.ModuleRoles.Remove(moduleToRemove);

        await _unitOfWork.Roles.UpdateAsync(role);

    }

    #endregion




    #region Private Methods
    private string CreateTemporaryPassword(int size, bool lowerCase = false)
    {
        Random _random = new Random();
        var builder = new StringBuilder(size);
        char offset = lowerCase ? 'a' : 'A';
        const int lettersOffset = 26;

        for (var i = 0; i < size; i++)
        {
            var @char = (char)_random.Next(offset, offset + lettersOffset);
            builder.Append(@char);
        }

        return lowerCase ? builder.ToString().ToLower() : builder.ToString();
    }
    private async Task SendWelcomeEmail(string email, string name, string temporaryPassword)
    {
        var template = await _unitOfWork.MailTemplates.FirstOrDefaultAsync(new TemplateById(3));
        var link = _configuration.GetValue<string>("SecuritySettings:LoginLinkUrl");
        var data = new { Name = name, Username = name, Password = temporaryPassword, LoginUrl = link };


        var mailRequest = new EmailRequest();
        mailRequest.To = new List<RecipientCustom> { new RecipientCustom() { Email = email, Name = name, Data = _jsonSerializer.Serialize(data) } };
        mailRequest.Subject = template.Name;
        mailRequest.HTMLTemplate = template.Url;
        mailRequest.IsUrlTemplate = template.IsHtml;
        mailRequest.IsCustomized = template.IsCustom;

        var mailResponse = await _notification.SendMail(mailRequest);
    }
    #endregion

}

