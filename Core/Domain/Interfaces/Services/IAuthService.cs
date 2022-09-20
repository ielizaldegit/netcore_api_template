using Core.Aplication.Auth;
using Core.Interfaces;

namespace Core.Domain.Interfaces.Services;

public interface IAuthService : IScopedService
{
    Task<UserDTO> LoginAsync(LoginRequestDTO request);
    Task<UserDTO> RegisterAsync(RegisterRequestDTO request);

}

