using Core.Application.Admin;
using Core.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace API.Controllers.Admin;

[Authorize(Roles = "Admin,Root")]
public class RoleController : VersionNeutralApiController
{
    private readonly IAdminService _authService;
    public RoleController(IAdminService authService) => _authService = authService;


    [HttpGet("get-all")]
    [OpenApiOperation("Obtiene una lista de todos los roles activos.", "")]
    public async Task<ActionResult<List<RoleResponse>>> GetAll()
    {
        var result = await _authService.GetAllRolesAsync();
        return Ok(result);
    }

    [HttpPost]
    [OpenApiOperation("Inserta un nuevo rol.", "")]
    public async Task<ActionResult<RoleResponse>> Post(CreateRoleRequest request)
    {
        var result = await _authService.AddRolesAsync(request);
        return Ok(result);
    }

    [HttpPut]
    [OpenApiOperation("Actualiza un rol.", "")]
    public async Task<ActionResult<RoleResponse>> Put(UpdateRoleRequest request)
    {
        var result = await _authService.UpdateRolesAsync(request);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    [OpenApiOperation("Elimina un rol.", "")]
    public async Task<ActionResult> Delete(int id)
    {
        await _authService.DeleteRoleAsync(id);
        return Ok();
    }



    [HttpPost("{id}/modules")]
    [OpenApiOperation("Agrega un módulo al rol", "")]
    public async Task<ActionResult> AddModule(int id, int moduleId,  int permissionId)
    {
        await _authService.AddRoleModuleAsync(id, moduleId, permissionId);
        return Ok();
    }
    [HttpDelete("{id}/modules")]
    [OpenApiOperation("Elimina un módulo del rol", "")]
    public async Task<ActionResult> DeleteModule(int id, int moduleId, int permissionId)
    {
        await _authService.DeleteRoleModuleAsync(id, moduleId, permissionId);
        return Ok();
    }


}

