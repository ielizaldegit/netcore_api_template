using AutoMapper;
using Core.Aplication.Auth;
using Core.Application.Auth;
using Core.Common.Exceptions;
using Core.Domain.Interfaces.Services;
using Core.Entities.Auth;
using Core.Entities.Persons;
using Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Core.Application.Profile;

public class ProfileService : IProfileService
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<AuthService> _logger;
    protected readonly ICurrentUser _currentUser;


    public ProfileService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<AuthService> logger, ICurrentUser currentUser)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
        _currentUser = currentUser;
    }


    public async Task<PersonDTO> UpdatePersonAsync(PersonRequestDTO request)
    {
        //Validar que la persona exista
        var persona = await _unitOfWork.Person.FirstOrDefaultAsync(new PersonById(request.PersonId));
        if (persona == null) throw new NotFoundException($"La persona con id ${request.PersonId } no fue encontrada");
        //Validar que la persona pertenezca al perfil del usuario
        var usuarios = persona.PersonUsers.Select(p => p.UserId).ToArray();
        if (!Array.Exists(usuarios, e => e == _currentUser.GetUserId())) throw new BadRequestException($"La persona que se intenta actualizar no pertenece al perfil del usuario logueado");

        //Procesar foto base64 en caso de recibir la imagen
        //TODO

        _mapper.Map(request, persona);


        await _unitOfWork.Person.UpdateAsync(persona);
        await _unitOfWork.SaveAsync();     

            


        PersonDTO dto = _mapper.Map<PersonDTO>(persona);
        return dto;
    }
}

