using System;
using Ardalis.Specification;
using Core.Domain.Entities.Mail;
using Core.Entities.Auth;

namespace Core.Application.Auth;

public class UserByName : Specification<User>
{
    public UserByName(string username) {
        Query.Include(u => u.Role)
                .Include(u => u.PersonUsers).ThenInclude(x => x.Relationship)
                .Include(u => u.PersonUsers).ThenInclude(x => x.Person)
                .Include(u => u.PersonUsers).ThenInclude(x => x.Person.Gender)
                .Include(u => u.PersonUsers).ThenInclude(x => x.Person.MaritalStatus)
                .Include(u => u.PersonUsers).ThenInclude(x => x.Person.Address)
                .Include(u => u.ModuleUsers).ThenInclude(x => x.Module)
                .Include(u => u.ModuleUsers).ThenInclude(x => x.Permission)
                .Where(u => u.Name.ToLower() == username.ToLower());

    }
}


public class UserById : Specification<User> {
    public UserById(int id) {
        Query.Where(u => u.UserId == id);
    }
}


public class RolebyId : Specification<Role> {
    public RolebyId(int id)
    {
        Query.Include(u => u.ModuleRoles).ThenInclude(u => u.Module)
               .Include(u => u.ModuleRoles).ThenInclude(x => x.Permission)
               .Where(u => u.RoleId == id);
    }

}

public class ActivationById : Specification<Activation>
{
    public ActivationById(Guid id)
    {
        Query.Where(u => u.ActivationId == id);
    }

}
