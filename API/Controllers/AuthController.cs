using Core.Aplication.Auth;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace API.Controllers;


public class AuthController : VersionNeutralApiController {


    private readonly IAuthService _authService;
    public AuthController(IAuthService authService) => _authService = authService;



    [HttpPost("login")]
    [OpenApiOperation("Inicio de sesión de un usuario registrado y activo.", "Descripción: Lorem Ipsum...")]
    public async Task<ActionResult<UserDTO>> LoginAsync(LoginRequestDTO model) {
        var result = await _authService.LoginAsync(model);
        return Ok(result);
    }


    [Authorize]
    [HttpPost("register")]
    [OpenApiOperation("Registra un nuevo usuario.", "Descripción: Lorem Ipsum...")]
    public async Task<ActionResult<UserDTO>> RegisterAsync(RegisterRequestDTO model) {
        string ClientIPAddr = HttpContext.Connection.RemoteIpAddress?.ToString();
        string test = HttpContext.Request.Headers["User-Agent"];

        var result = await _authService.RegisterAsync(model);
        return Ok(result);
    }

}


