using Core.Application.Admin;
using Core.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace API.Controllers.Admin;

[Authorize(Roles = "Admin,Root")]
public class ModuleController : VersionNeutralApiController
{
    private readonly IAdminService _authService;
    public ModuleController(IAdminService authService) => _authService = authService;

    [HttpGet("get-all")]
    [OpenApiOperation("Obtiene una lista de todos los módulos activos.", "")]
    public async Task<ActionResult<List<ModuleResponse>>> GetAll()
    {
        var result = await _authService.GetAllModulesAsync();
        return Ok(result);
    }

    [HttpPost]
    [OpenApiOperation("Inserta un nuevo módulo.", "")]
    public async Task<ActionResult<ModuleResponse>> Post(CreateModuleRequest request)
    {
        var result = await _authService.AddModulesAsync(request);
        return Ok(result);
    }

    [HttpPut]
    [OpenApiOperation("Actualiza un módulo.", "")]
    public async Task<ActionResult<ModuleResponse>> Put(UpdateModuleRequest request)
    {
        var result = await _authService.UpdateModulesAsync(request);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    [OpenApiOperation("Elimina un módulo.", "")]
    public async Task<ActionResult> Delete(int id)
    {
        await _authService.DeleteModuleAsync(id);
        return Ok();
    }



    [HttpPost("{id}/permissions")]
    [OpenApiOperation("Agrega un permiso al módulo", "")]
    public async Task<ActionResult> AddPermission(int id, int permissionId)
    {
        await _authService.AddModulePermissionAsync(id, permissionId);
        return Ok();
    }
    [HttpDelete("{id}/permissions")]
    [OpenApiOperation("Elimina un permiso del módulo", "")]
    public async Task<ActionResult> DeletePermission(int id, int permissionId)
    {
        await _authService.DeleteModulePermissionAsync(id, permissionId);
        return Ok();
    }
    [HttpPut("{id}/permissions")]
    [OpenApiOperation("Actualiza multiples permisos en un módulo", "")]
    public async Task<ActionResult> UpdatePermissions(int id, UpdateModulePermissionRequest request)
    {
        await _authService.UpdateModulePermissionAsync(id, request.Ids);
        return Ok();
    }

}

