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
    [OpenApiOperation("Actualiza el perfil de usuario", "Descripción: Lorem Ipsum...")]
    public async Task<ActionResult<PersonDTO>> UpdatePerson(PersonRequestDTO request)
    {
        var result = await _profileService.UpdatePersonAsync(request);
        return Ok(result);
    }
}

