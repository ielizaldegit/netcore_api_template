using System;
using Core.Entities.Auth;

namespace Core.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByUsernameAsync(string username);
        public string GenerateJwt(User user);
    }
}

