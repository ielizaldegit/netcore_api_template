using System.Net;
using API.DTOs;
using API.Helpers.Errors;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class AuthController : BaseApiController {


    private readonly IAuthService _authService;
    private readonly ILogger<AuthController> _logger;


    public AuthController(IAuthService authService, ILogger<AuthController> logger) {
        _authService = authService;
        _logger = logger;
        _logger.LogInformation("Testing logging in AuthController");
    }



    /// <summary>
    /// Inicio de sesión de un usuario registrado y activo
    /// </summary>
    /// <remarks>
    /// Description:
    /// Lorem Ipsum...
    /// </remarks>
    [HttpPost("login")]
    public async Task<ActionResult<UserDTO>> LoginAsync(LoginRequestDTO model)
    {
        try  {
            var result = await _authService.LoginAsync(model);
            return Ok(result);
        }
        catch (Exception ex) {
            return HandleErrors(ex);
        }
    }




    /// <summary>
    /// Registra un nuevo usuario
    /// </summary>
    /// <remarks>
    /// Description:
    /// Lorem Ipsum...
    /// </remarks>
    [Authorize]
    [HttpPost("register")]
    public async Task<ActionResult<UserDTO>> RegisterAsync(RegisterRequestDTO model)
    {

        string ClientIPAddr = HttpContext.Connection.RemoteIpAddress?.ToString();
        string test = HttpContext.Request.Headers["User-Agent"];
        //model.CreatedAt = DateTime.Now;
        //model.CreatedBy = CurrentUserId;

        //var roleid = CurrentRoleId;
        var result = await _authService.RegisterAsync(model);
        return Ok(result);
    }

}


