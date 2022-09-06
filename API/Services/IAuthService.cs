using System;
using API.DTOs;

namespace API.Services
{
    public interface IAuthService
    {
        Task<UserDTO> LoginAsync(LoginRequestDTO request);
        Task<UserDTO> RegisterAsync(RegisterRequestDTO request);
        
    }
}

