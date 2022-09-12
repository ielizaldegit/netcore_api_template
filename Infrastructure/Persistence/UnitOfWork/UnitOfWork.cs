using Core.Entities.Auth;
using Core.Interfaces;
using Infrastructure.Auth;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Options;

namespace Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        private readonly ApplicationDbContext _context;
        
        private IAuthRepository _auth;
        private IUserRepository _users;
        private IRoleRepository _roles;
        private readonly JwtSettings _jwtSettings;


        public UnitOfWork(ApplicationDbContext context, IOptions<JwtSettings> jwtSettings) {
            _context = context;
            _jwtSettings = jwtSettings.Value;
        }

        public IAuthRepository Auth {
            get { return _auth = _auth ?? new AuthRepository(_context); }
        }

        public IUserRepository Users {
            get { return _users = _users ?? new UserRepository(_context, _jwtSettings); }
        }

        public IGenericRepository<Role> Roles
        {
            get { return _roles = _roles ?? new RoleRepository(_context); }
        }


        public async Task<int> SaveAsync() {
            return await _context.SaveChangesAsync();
        }


        //public async Task<int> SaveAsync(int UserId)
        //{
        //    return await _context.SaveChangesAsync(UserId);
        //}


        public void Dispose() {
            _context.Dispose();
        }


    }
}

