using Core.Application.Admin;
using Core.Interfaces;


namespace Core.Domain.Interfaces.Services;

public interface IAdminService : IScopedService
{
    Task<List<UserResponse>> GetAllUsersAsync();
    Task<UserResponse> RegisterAsync(CreateUserRequest request);
    Task UpdatePasswordAsync(UpdatePasswordRequest request);

    Task<List<PermissionResponse>> GetAllPermissionsAsync();
    Task<List<PermissionResponse>> GetParentPermissionsAsync();
    Task<PermissionResponse> AddPermissionsAsync(CreatePermissionRequest request);
    Task<PermissionResponse> UpdatePermissionsAsync(UpdatePermissionRequest request);
    Task DeletePermissionsAsync(int id);


    Task<List<ModuleResponse>> GetAllModulesAsync();
    Task<ModuleResponse> AddModulesAsync(CreateModuleRequest request);
    Task<ModuleResponse> UpdateModulesAsync(UpdateModuleRequest request);
    Task DeleteModuleAsync(int id);
    Task AddModulePermissionAsync(int ModuleId, int PermissionId);
    Task DeleteModulePermissionAsync(int ModuleId, int PermissionId);
    Task UpdateModulePermissionAsync(int ModuleId, int[] PermissionIds);


    Task<List<RoleResponse>> GetAllRolesAsync();
    Task<RoleResponse> AddRolesAsync(CreateRoleRequest request);
    Task<RoleResponse> UpdateRolesAsync(UpdateRoleRequest request);
    Task DeleteRoleAsync(int id);
    Task<List<ModuleResponse>> GetRoleModulesAsync(int RoleId);
    Task AddRoleModuleAsync(int RoleId, int ModuleId, int PermissionId);
    Task DeleteRoleModuleAsync(int RoleId, int ModuleId, int PermissionId);
}

