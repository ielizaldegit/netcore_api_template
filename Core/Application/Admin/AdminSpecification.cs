using Ardalis.Specification;
using Core.Entities.Auth;

namespace Core.Application.Admin;


public class SearchAllUsers : Specification<User> {
    public SearchAllUsers()  {
        Query
            .Include(u => u.Role)
            .Where(u => u.IsActive == true);
    }
}


public class SearchAllPermissions : Specification<Permission> {
    public SearchAllPermissions() {
        Query
            .Where(u => u.IsActive == true);
    }
}
public class GetParentPermissions : Specification<Permission> {
    public GetParentPermissions() {
        Query
            .Where(u => u.IsActive == true)
            .Where(u => u.Grouping == true);
    }
}
public class GetPermissionsByName : Specification<Permission> {
    public GetPermissionsByName(string name) {
        Query
            .Where(u => u.IsActive == true)
            .Where(u => u.Name == name);
    }
}
public class GetPermissionsById : Specification<Permission> {
    public GetPermissionsById(int id) {
        Query
            .Where(u => u.IsActive == true)
            .Where(u => u.PermissionId == id);
    }
}


public class SearchAllModules : Specification<Module>
{
    public SearchAllModules()
    {
        Query
            .Where(u => u.IsActive == true);
    }
}
public class GetModuleByName : Specification<Module> {
    public GetModuleByName(string name) {
        Query
            .Where(u => u.IsActive == true)
            .Where(u => u.Name == name);
    }
}
public class GetModulesById : Specification<Module> {
    public GetModulesById(int id) {
        Query
            .Include(u => u.ModulePermissions)
            .Where(u => u.IsActive == true)
            .Where(u => u.ModuleId == id);
    }
}


public class SearchAllRoles : Specification<Role> {
    public SearchAllRoles() {
        Query
            .Where(u => u.IsActive == true);
    }
}
public class GetRoleByName : Specification<Role>
{
    public GetRoleByName(string name)
    {
        Query
            .Where(u => u.IsActive == true)
            .Where(u => u.Name == name);
    }
}
public class GetRoleById : Specification<Role>
{
    public GetRoleById(int id)
    {
        Query
            .Where(u => u.IsActive == true)
            .Where(u => u.RoleId == id);
    }
}
