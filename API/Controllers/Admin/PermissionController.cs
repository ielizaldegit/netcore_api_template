using Core.Application.Admin;
using Core.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace API.Controllers.Admin;

[Authorize(Roles = "Admin,Root")]
public class PermissionController : VersionNeutralApiController
{
    private readonly IAdminService _authService;
    public PermissionController(IAdminService authService) => _authService = authService;



    [HttpGet("get-all")]
    [OpenApiOperation("Obtiene una lista de todos los permisos activos.", "")]
    public async Task<ActionResult<List<PermissionResponse>>> GetAll()
    {
        var result = await _authService.GetAllPermissionsAsync();
        return Ok(result);
    }

    [HttpGet("get-parents")]
    [OpenApiOperation("Obtiene una lista de todos los permisos padres.", "")]
    public async Task<ActionResult<List<PermissionResponse>>> GetParents()
    {
        var result = await _authService.GetParentPermissionsAsync();
        return Ok(result);
    }

    [HttpPost]
    [OpenApiOperation("Inserta un nuevo permiso.", "")]
    public async Task<ActionResult<PermissionResponse>> Post(CreatePermissionRequest request)
    {
        var result = await _authService.AddPermissionsAsync(request);
        return Ok(result);
    }

    [HttpPut]
    [OpenApiOperation("Actualiza un permiso.", "")]
    public async Task<ActionResult<PermissionResponse>> Put(UpdatePermissionRequest request)
    {
        var result = await _authService.UpdatePermissionsAsync(request);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    [OpenApiOperation("Elimina un permiso.", "")]
    public async Task<ActionResult> Delete(int id)
    {
        await _authService.DeletePermissionsAsync(id);
        return Ok();
    }

}

