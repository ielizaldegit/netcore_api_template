using Core.Application.Profile;
using Core.Interfaces;

namespace Core.Domain.Interfaces.Services;

public interface IProfileService : IScopedService
{

    Task<PersonResponse> AddPersonAsync(CreatePersonRequest request);
    Task<PersonResponse> UpdatePersonAsync(UpdatePersonRequest request);
    Task<PhotoResponseDTO> UpdatePhotoAsync(PhotoRequestDTO request);

    Task<AddressResponse> AddAddressAsync(CreateAddressRequest request);
    Task<AddressResponse> UpdateAddressAsync(UpdateAddressRequest request);

    void UpdatePasswordAsync(UpdatePasswordRequest request);
}

