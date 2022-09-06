using Core.Entities.Auth;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository {
        public AuthRepository(ApplicationDbContext context)
        {
        }
    }



    public class UserRepository : GenericRepository<User>, IUserRepository {
        public UserRepository(ApplicationDbContext context) : base(context) { }
        public async Task<User> GetByUsernameAsync(string username) {
            return await _context.Users
                    .Include(u => u.Role)
                    .Include(u => u.PersonUsers).ThenInclude(x => x.Person)
                    .Include(u => u.PersonUsers).ThenInclude(x => x.Person.Gender)
                    .Include(u => u.PersonUsers).ThenInclude(x => x.Person.MaritalStatus)
                    .Include(u => u.PersonUsers).ThenInclude(x => x.Person.Address)
                    .Include(u => u.ModuleUsers).ThenInclude(x => x.Module)
                    .Include(u => u.ModuleUsers).ThenInclude(x => x.Permission)
                    .FirstOrDefaultAsync(u => u.Name.ToLower() == username.ToLower());
        }
    }


    public class RoleRepository : GenericRepository<Role>, IRoleRepository {
        public RoleRepository(ApplicationDbContext context) : base(context) { }
        public override async Task<Role> GetByIdAsync(int id) {
            return await _context.Roles
                  .Include(u => u.ModuleRoles).ThenInclude(u => u.Module)
                  .Include(u => u.ModuleRoles).ThenInclude(x => x.Permission)
                  .FirstOrDefaultAsync(u => u.RoleId == id);
        }
    }





}

