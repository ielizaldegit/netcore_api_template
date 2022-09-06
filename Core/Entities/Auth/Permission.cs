using System;
using System.Reflection;

namespace Core.Entities.Auth
{
    public class Permission
    {

        public int PermissionId { get; set; }
        public string Name { get; set; }
        public string DisplayText { get; set; }
        public string CssClass { get; set; }
        public string Description { get; set; }
        public bool? Grouping { get; set; }
        public int? DisplayOrder { get; set; }
        public bool? IsVisible { get; set; }
        public bool? IsActive { get; set; }
        public int? ParentId { get; set; }
        public Permission Parent { get; set; }
        public ICollection<Permission> Childs { get; set; }

        public ICollection<ModulePermission> ModulePermissions { get; set; }
        public ICollection<ModuleUser> ModuleUsers { get; set; }
        public ICollection<ModuleRole> ModuleRoles { get; set; }

    }
}

