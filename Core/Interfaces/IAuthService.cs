using System;
using Core.DTOs;

namespace Core.Interfaces
{
    public interface IAuthService
    {
        Task<UserDTO> LoginAsync(LoginRequestDTO request);
        Task<UserDTO> RegisterAsync(RegisterRequestDTO request);

    }
}

