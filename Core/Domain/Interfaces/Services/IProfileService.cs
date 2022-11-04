using Core.Application.Common.Models;
using Core.Application.Profile;
using Core.Interfaces;

namespace Core.Domain.Interfaces.Services;

public interface IProfileService : IScopedService
{
    Task<PaginationResponse<PersonResponse>> GetAllPersonsAsync(SearchPersonRequest request);

    Task<PersonResponse> AddPersonAsync(CreatePersonRequest request);
    Task<PersonResponse> UpdatePersonAsync(UpdatePersonRequest request);
    Task<PhotoResponse> UpdatePhotoAsync(PhotoRequest request);

    Task<AddressResponse> AddAddressAsync(CreateAddressRequest request);
    Task<AddressResponse> UpdateAddressAsync(UpdateAddressRequest request);

    Task UpdatePasswordAsync(UpdatePasswordRequest request);
}

