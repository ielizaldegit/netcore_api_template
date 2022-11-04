using Core.Application.Auth;
using Core.Interfaces;

namespace Core.Domain.Interfaces.Services;

public interface IAuthService : IScopedService
{
    Task<LoginResponse> LoginAsync(LoginRequest request);
    Task<LoginResponse> RegisterAsync(RegisterRequest request);
    Task ActivateAccountAsync(Guid activationId);
    Task SendActivationCodeAsync(string email);
    Task SetNewPasswordAsync(NewPasswordRequest request);
    Task SendRecoveryCodeAsync(string email);
    
}

