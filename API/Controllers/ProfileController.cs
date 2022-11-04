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



    [HttpPost("get_persons")]
    [OpenApiOperation("Obtiene todas las personas", "")]
    public async Task<ActionResult<PersonResponse>> GetAllPersons(SearchPersonRequest request)
    {
        var result = await _profileService.GetAllPersonsAsync(request);
        return Ok(result);
    }


    [HttpPost("add_person")]
    [OpenApiOperation("Agrega una nueva persona", "")]
    public async Task<ActionResult<PersonResponse>> AddPerson(CreatePersonRequest request)
    {
        var result = await _profileService.AddPersonAsync(request);
        return Ok(result);
    }


    [HttpPut("update_person")]
    [OpenApiOperation("Actualiza el perfil de usuario", "")]
    public async Task<ActionResult<PersonResponse>> UpdatePerson(UpdatePersonRequest request)
    {
        var result = await _profileService.UpdatePersonAsync(request);
        return Ok(result);
    }

    [HttpPut("update_photo")]
    [OpenApiOperation("Actualiza la foto de perfil del usuario", "")]
    public async Task<ActionResult<PhotoResponse>> UpdatePhoto(PhotoRequest request)
    {
        var result = await _profileService.UpdatePhotoAsync(request);
        return Ok(result);
    }


    [HttpPost("add_address")]
    [OpenApiOperation("Agrega un domicilio a una persona", "")]
    public async Task<ActionResult<AddressResponse>> AddAddress(CreateAddressRequest request)
    {
        var result = await _profileService.AddAddressAsync(request);
        return Ok(result);
    }


    [HttpPut("update_address")]
    [OpenApiOperation("Actualiza el domicilio de una persona", "")]
    public async Task<ActionResult<AddressResponse>> UpdateAddress(UpdateAddressRequest request)
    {
        var result = await _profileService.UpdateAddressAsync(request);
        return Ok(result);
    }


    [HttpPut("update_password")]
    [OpenApiOperation("Actualiza el password de un usuario", "")]
    public async Task<ActionResult> UpdatePassword(UpdatePasswordRequest request)
    {
        await _profileService.UpdatePasswordAsync(request);
        return Ok();
    }

}

