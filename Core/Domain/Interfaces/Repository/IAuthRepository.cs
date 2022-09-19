using Core.Entities.Auth;

namespace Core.Interfaces.Repository
{
    public interface IAuthRepository 
    {
        public string GenerateJwt(User user);
    }
}

