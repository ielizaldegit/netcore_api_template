using AutoMapper;
using Core.Common.Exceptions;
using Core.Domain.Interfaces.Services;
using Core.Interfaces;

namespace Core.Application.Profile;

public class ProfileService : IProfileService
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    protected readonly ICurrentUser _currentUser;


    public ProfileService(IUnitOfWork unitOfWork, IMapper mapper, ICurrentUser currentUser)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _currentUser = currentUser;
    }


    public Task<PersonResponse> AddPersonAsync(CreatePersonRequest request)
    {
        throw new NotImplementedException();
    }
    public async Task<PersonResponse> UpdatePersonAsync(UpdatePersonRequest request)
    {
        //Validar que la persona exista
        var persona = await _unitOfWork.Person.FirstOrDefaultAsync(new PersonById(request.PersonId));
        if (persona == null) throw new NotFoundException($"La persona con id {request.PersonId} no fue encontrada");

        if (!_currentUser.IsInRole("Root"))
        {
            //Validar que la persona pertenezca al perfil del usuario
            var usuarios = persona.PersonUsers.Select(p => p.UserId).ToArray();
            if (!Array.Exists(usuarios, e => e == _currentUser.GetUserId())) throw new BadRequestException($"La persona que se intenta actualizar no pertenece al perfil del usuario logueado");
        }

        _mapper.Map(request, persona);

        await _unitOfWork.Person.UpdateAsync(persona);
        await _unitOfWork.SaveAsync();     

        return _mapper.Map<PersonResponse>(persona);
    }

    public async Task<PhotoResponseDTO> UpdatePhotoAsync(PhotoRequestDTO request)
    {
        //Validar que la persona exista
        var persona = await _unitOfWork.Person.FirstOrDefaultAsync(new PersonById(request.PersonId));
        if (persona == null) throw new NotFoundException($"La persona con id ${request.PersonId} no fue encontrada");

        //TODO: Procesar foto base64 en caso de recibir la imagen

        return null;
    }


    public Task<AddressResponse> AddAddressAsync(CreateAddressRequest request)
    {
        throw new NotImplementedException();
    }
    public async Task<AddressResponse> UpdateAddressAsync(UpdateAddressRequest request)
    {
        throw new NotImplementedException();
    }


    public async void UpdatePasswordAsync(UpdatePasswordRequest request)
    {
        throw new NotImplementedException();
    }
}

