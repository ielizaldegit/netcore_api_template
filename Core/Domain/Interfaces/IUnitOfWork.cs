using System;
using Core.Entities.Auth;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IScopedService
    {
        IAuthRepository Auth { get; }
        IUserRepository Users { get; }
        IGenericRepository<Role> Roles { get; }

        Task<int> SaveAsync();
     }

}

