using Core.Aplication.Auth;

namespace Core.Interfaces.Services
{
    public interface IAuthService : IScopedService
    {
        Task<UserDTO> LoginAsync(LoginRequestDTO request);
        Task<UserDTO> RegisterAsync(RegisterRequestDTO request);

    }
}

