using System;
using Ardalis.Specification;
using Core.Entities.Auth;

namespace Core.Application.Auth
{

    public class UserByName : Specification<User>
    {
        public UserByName(string username)
        {
            Query.Include(u => u.Role)
                    .Include(u => u.PersonUsers).ThenInclude(x => x.Person)
                    .Include(u => u.PersonUsers).ThenInclude(x => x.Person.Gender)
                    .Include(u => u.PersonUsers).ThenInclude(x => x.Person.MaritalStatus)
                    .Include(u => u.PersonUsers).ThenInclude(x => x.Person.Address)
                    .Include(u => u.ModuleUsers).ThenInclude(x => x.Module)
                    .Include(u => u.ModuleUsers).ThenInclude(x => x.Permission)
                    .Where(u => u.Name.ToLower() == username.ToLower() && u.IsActive == true);

        }
    }


    public class RolebyId : Specification<Role>
    {
        public RolebyId(int id)
        {
            Query.Include(u => u.ModuleRoles).ThenInclude(u => u.Module)
                   .Include(u => u.ModuleRoles).ThenInclude(x => x.Permission)
                   .Where(u => u.RoleId == id);
        }

    }

}

