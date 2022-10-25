using System;
namespace Core.Entities.Auth;

public class Module: AuditBaseEntity
{

    public int ModuleId { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string Subtitle { get; set; }
    public string Description { get; set; }
    public string Route { get; set; }
    public string CssClass { get; set; }
    public int? DisplayOrder { get; set; }
    public bool? IsVisible { get; set; }
    public bool? IsActive { get; set; }
    public int? ParentId { get; set; }
    public Module Parent { get; set; }
    public ICollection<Module> Children { get; set; }

    public ICollection<ModulePermission> ModulePermissions { get; set; }
    public ICollection<ModuleUser> ModuleUsers { get; set; }
    public ICollection<ModuleRole> ModuleRoles { get; set; }

}


public class ModulePermission
{
    public int ModuleId { get; set; }
    public int PermissionId { get; set; }

    public Module Module { get; set; }
    public Permission Permission { get; set; }

}

public class ModuleUser
{
    public int ModuleId { get; set; }
    public int UserId { get; set; }
    public int PermissionId { get; set; }


    public Module Module { get; set; }
    public User User { get; set; }
    public Permission Permission { get; set; }
}

public class ModuleRole
{
    public int ModuleId { get; set; }
    public int RoleId { get; set; }
    public int PermissionId { get; set; }

    public Module Module { get; set; }
    public Role Role { get; set; }
    public Permission Permission { get; set; }
}


