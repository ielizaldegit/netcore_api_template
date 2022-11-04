using Core.Application.Admin;
using Core.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace API.Controllers.Admin;

[Authorize(Roles = "Admin,Root")]
public class UserController : VersionNeutralApiController
{
    private readonly IAdminService _authService;
    public UserController(IAdminService authService) => _authService = authService;


    [HttpGet ("get-all")]
    [OpenApiOperation("Obtiene una lista de todos los usuarios activos.", "")]
    public async Task<ActionResult<List<UserResponse>>> GetAll()
    {
        var result = await _authService.GetAllUsersAsync();
        return Ok(result);
    }


    [HttpGet("{id}")]
    [OpenApiOperation("Obtiene los detalles de un usuario por su Id", "")]
    public async Task<ActionResult<UserResponse>> GetByIdAsync(int id)
    {
        var result = await _authService.GetAllUsersAsync();
        return Ok(result);// _userService.GetAsync(id, cancellationToken);
    }



    [HttpPost("register")]
    [OpenApiOperation("Registra un usuario en el sistema.", "")]
    public async Task<ActionResult<UserResponse>> Register(CreateUserRequest request)
    {
        var result = await _authService.RegisterAsync(request);
        return Ok(result);
    }





}

