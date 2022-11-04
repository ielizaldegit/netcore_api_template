using System.Text.RegularExpressions;
using Core.Application.Auth;
using Core.Common.Exceptions;
using Core.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace API.Controllers;


public class AuthController : VersionNeutralApiController {


    private readonly IAuthService _authService;
    public AuthController(IAuthService authService) => _authService = authService;



    [HttpPost("login")]
    [OpenApiOperation("Inicio de sesión de un usuario registrado y activo.", "Descripción: Lorem Ipsum...")]
    public async Task<ActionResult<LoginResponse>> Login(LoginRequest request) {
        var result = await _authService.LoginAsync(request);
        return Ok(result);
    }

    [HttpPost("self-register")]
    [OpenApiOperation("Registra un nuevo usuario.", "Descripción: Lorem Ipsum...")]
    public async Task<ActionResult<LoginResponse>> Register(RegisterRequest request)
    {
        request.RoleId = 3;
        var result = await _authService.RegisterAsync(request);
        return Ok(result);
    }

    [HttpPost("send-activation-code/{email}")]
    [OpenApiOperation("Envia un correo electrónico con un código de activacion de cuenta", "Descripción: Lorem Ipsum...")]
    public async Task<ActionResult> SendActivationCode(string email)
    {
        var regex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
        if (!Regex.IsMatch(email, regex, RegexOptions.IgnoreCase)) throw new BadRequestException("El correo electrónico proporcionado no tiene un formato válido");

        await _authService.SendActivationCodeAsync(email);
        return Ok();
    }


    [HttpPut("activate-account/{id}")]
    [OpenApiOperation("Activa una cuenta utilizado un código de activación", "Descripción: Lorem Ipsum...")]
    public async Task<ActionResult> ActivateAccount(string id)
    {
        if (!Guid.TryParse(id, out var guid)) throw new BadRequestException("El identificador proporcionado no tiene un formato válido");

        await _authService.ActivateAccountAsync(guid);
        return Ok();
    }


    [HttpPost("forgot-password/{email}")]
    [OpenApiOperation("Envia un correo electrónico con un código de recuperación de contraseña", "Descripción: Lorem Ipsum...")]
    public async Task<ActionResult> SendRecoveryCode(string email)
    {
        var regex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
        if (!Regex.IsMatch(email, regex, RegexOptions.IgnoreCase)) throw new BadRequestException("El correo electrónico proporcionado no tiene un formato válido");

        await _authService.SendRecoveryCodeAsync(email);
        return Ok();
    }


    [HttpPut("reset-password")]
    [OpenApiOperation("Establece una nueva contraseña en la cuenta de usuario", "Descripción: Lorem Ipsum...")]
    public async Task<ActionResult> SetNewPassword(NewPasswordRequest request)
    {
        await _authService.SetNewPasswordAsync(request);
        return Ok();
    }




}


