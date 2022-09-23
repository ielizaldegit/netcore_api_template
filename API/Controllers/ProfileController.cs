using Core.Application.Profile;
using Core.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace API.Controllers;

[Authorize]
public class ProfileController : VersionNeutralApiController
{

    private readonly IProfileService _profileService;
    public ProfileController(IProfileService profileService) => _profileService = profileService;



    [HttpPost("update_person")]
    [OpenApiOperation("Actualiza el perfil de usuario", "")]
    public async Task<ActionResult<PersonResponse>> UpdatePerson(UpdatePersonRequest request)
    {
        var result = await _profileService.UpdatePersonAsync(request);
        return Ok(result);
    }


    [HttpPost("update_address")]
    [OpenApiOperation("Actualiza el domicilio de una persona", "")]
    public async Task<ActionResult<PersonResponse>> UpdateAddress(UpdatePersonRequest request)
    {
        var result = await _profileService.UpdatePersonAsync(request);
        return Ok(result);
    }

}

