using Core.DTOs;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace API.Controllers;


public class AuthController : VersionNeutralApiController {


    private readonly IAuthService _authService;
    private readonly ILogger<AuthController> _logger;


    public AuthController(IAuthService authService, ILogger<AuthController> logger)
    {
        _authService = authService;
        _logger = logger;
    }



    [HttpPost("login")]
    [OpenApiOperation("Inicio de sesión de un usuario registrado y activo.", "Descripción: Lorem Ipsum...")]
    public async Task<ActionResult<UserDTO>> LoginAsync(LoginRequestDTO model)
    {
        var result = await _authService.LoginAsync(model);
        return Ok(result);
    }


    [Authorize]
    [HttpPost("register")]
    [OpenApiOperation("Registra un nuevo usuario.", "Descripción: Lorem Ipsum...")]
    public async Task<ActionResult<UserDTO>> RegisterAsync(RegisterRequestDTO model)
    {
        string ClientIPAddr = HttpContext.Connection.RemoteIpAddress?.ToString();
        string test = HttpContext.Request.Headers["User-Agent"];

        var result = await _authService.RegisterAsync(model);
        return Ok(result);
    }

}


