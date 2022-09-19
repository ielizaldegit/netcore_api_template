using Ardalis.Specification;
using Core.Entities.Auth;
using Core.Interfaces.Repository;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IScopedService
    {
        IAuthRepository Auth { get; }
        IRepositoryBase<User> Users { get; }
        IRepositoryBase<Role> Roles { get; }

        Task<int> SaveAsync();
     }

}

