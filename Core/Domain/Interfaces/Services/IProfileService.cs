using Core.Aplication.Auth;
using Core.Application.Profile;
using Core.Interfaces;

namespace Core.Domain.Interfaces.Services;

public interface IProfileService : IScopedService
{
    Task<PersonDTO> UpdatePersonAsync(PersonRequestDTO request);

}

