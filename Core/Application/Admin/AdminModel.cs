using Core.Application.Common.Models;
using Core.Application.Profile;
using Core.Entities.Auth;

namespace Core.Application.Admin;

public class CreateUserRequest {
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsTemporaryPassword { get; set; }
    public int RoleId { get; set; }
}
public class UserResponse: CreateUserRequest {
    public int UserId { get; set; }
    public string Role { get; set; }
    public bool EmailConfirmed { get; set; }
    public bool IsActive { get; set; }
    public PersonResponse Profile { get; set; }
}


public class UpdatePasswordRequest
{
    public int UserId { get; set; }
    public string Password { get; set; }
    public bool IsTemporaryPassword { get; set; }
}




public class CreatePermissionRequest {
    public string Name { get; set; }
    public string DisplayText { get; set; }
    public string CssClass { get; set; } = "";
    public string Description { get; set; } = "";
    public bool Grouping { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsVisible { get; set; } = true;
    public int? ParentId { get; set; }
}
public class UpdatePermissionRequest : CreatePermissionRequest {
    public int PermissionId { get; set; }

}
public class PermissionResponse : UpdatePermissionRequest {
    public string Parent { get; set; }
    public bool IsActive { get; set; } = true;
}


public class CreateModuleRequest
{
    public string Name { get; set; }
    public string Title { get; set; }
    public string Subtitle { get; set; } = "";
    public string Description { get; set; } = "";
    public string Route { get; set; } = "";
    public string CssClass { get; set; } = "";
    public int DisplayOrder { get; set; }
    public bool IsVisible { get; set; } = true;
    public int? ParentId { get; set; }
}
public class UpdateModuleRequest : CreateModuleRequest
{
    public int ModuleId { get; set; }
}
public class ModuleResponse : UpdateModuleRequest
{
    public bool IsActive { get; set; }
    public string Parent { get; set; }

    public ICollection<ModuleResponse> Children { get; set; }
    public ICollection<PermissionResponse> Permissions { get; set; }
}
public class UpdateModulePermissionRequest
{
    public int[] Ids { get; set; }
}




public class CreateRoleRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
}
public class UpdateRoleRequest : CreateRoleRequest
{
    public int RoleId { get; set; }
    
}
public class RoleResponse: UpdateRoleRequest
{
    public bool IsActive { get; set; }
}
public class UpdateRoleModuleRequest
{
    public List<RoleModuleRequest> Modules { get; set; }
}
public class RoleModuleRequest
{
    public int ModuleId { get; set; }
    public int PermissionId { get; set; }
}