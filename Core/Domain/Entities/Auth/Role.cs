using System;
using Core.Entities;

namespace Core.Entities.Auth;

public class Role
{
    public int RoleId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public ICollection<User> Users { get; set; }

    public ICollection<ModuleRole> ModuleRoles { get; set; }
}

