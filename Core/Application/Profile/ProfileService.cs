using System.Threading;
using AutoMapper;
using Core.Application.Auth;
using Core.Application.Common.Especifications;
using Core.Application.Common.Models;
using Core.Common.Exceptions;
using Core.Domain.Interfaces.Services;
using Core.Entities.Auth;
using Core.Entities.Persons;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Core.Application.Profile;

public class ProfileService : IProfileService
{
    private readonly IConfiguration _configuration;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IStorageService _storage;
    protected readonly ICurrentUser _currentUser;
    private readonly IPasswordHasher<User> _passwordHasher;

    public ProfileService(IUnitOfWork unitOfWork, IMapper mapper, ICurrentUser currentUser, IConfiguration configuration, IStorageService storage, IPasswordHasher<User> passwordHasher)
    {
        _configuration = configuration;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _currentUser = currentUser;
        _storage = storage;
        _passwordHasher = passwordHasher;
    }


    public async Task<PaginationResponse<PersonResponse>> GetAllPersonsAsync(SearchPersonRequest request)
    {
        var spec = new SearchPerson(request);
        var result = await _unitOfWork.Person.PaginatedListAsync<Person, PersonResponse>(spec, request.Pagination.PageNumber, request.Pagination.PageSize, _mapper);
        return result;
    }



    public async Task<PersonResponse> AddPersonAsync(CreatePersonRequest request)
    {
        var photo = _configuration.GetValue<string>("SecuritySettings:DefaultUserPhoto");
        Person persona = new Person();
        _mapper.Map(request, persona);
        persona.Address = new Address() { };
        persona.Photo = photo;

        persona = await _unitOfWork.Person.AddAsync(persona);
        persona = await _unitOfWork.Person.FirstOrDefaultAsync(new PersonById(persona.PersonId));
        return _mapper.Map<PersonResponse>(persona);
    }
    public async Task<PersonResponse> UpdatePersonAsync(UpdatePersonRequest request)
    {
        //Validar que la persona exista
        var persona = await _unitOfWork.Person.FirstOrDefaultAsync(new PersonById(request.PersonId));
        if (persona == null) throw new NotFoundException($"La persona con id {request.PersonId} no fue encontrada");

        //if (!_currentUser.IsInRole("Root"))
        //{
        //    //Validar que la persona pertenezca al perfil del usuario
        //    var usuarios = persona.PersonUsers.Select(p => p.UserId).ToArray();
        //    if (!Array.Exists(usuarios, e => e == _currentUser.GetUserId())) throw new BadRequestException($"La persona que se intenta actualizar no pertenece al perfil del usuario logueado");
        //}

        _mapper.Map(request, persona);

        await _unitOfWork.Person.UpdateAsync(persona);

        persona = await _unitOfWork.Person.FirstOrDefaultAsync(new PersonById(request.PersonId));

        return _mapper.Map<PersonResponse>(persona);
    }
    public async Task<PhotoResponse> UpdatePhotoAsync(PhotoRequest request)
    {
        //Validar que la persona exista
        var persona = await _unitOfWork.Person.FirstOrDefaultAsync(new PersonById(request.PersonId));
        if (persona == null) throw new NotFoundException($"La persona con id ${request.PersonId} no fue encontrada");

        var blob = new CreateBlobRequest()
        {
            BlobBase64 = request.Photo.Data,
            FileName = request.Photo.Name,
            FolderName = "person-" + request.PersonId.ToString("0000000")+"/",
            HasDefaultName = false,
            Type = request.Photo.Type
        };

        var response = await _storage.UploadBlob(blob);

        var result = new PhotoResponse() {
             PersonId = request.PersonId,
             PhotoUrl = response.Url
        };

        persona.Photo = response.Url;

        await _unitOfWork.Person.UpdateAsync(persona);

        return result;
    }

    public async Task<AddressResponse> AddAddressAsync(CreateAddressRequest request)
    {
        Address address = new Address();
        _mapper.Map(request, address);

        await _unitOfWork.Addresses.UpdateAsync(address);

        return _mapper.Map<AddressResponse>(address);
    }
    public async Task<AddressResponse> UpdateAddressAsync(UpdateAddressRequest request)
    {
        //Validar que la dirección exista
        var address = await _unitOfWork.Addresses.FirstOrDefaultAsync(new AddressById(request.AddressId));
        if (address == null) throw new NotFoundException($"La dirección con id {request.AddressId} no fue encontrada");

        _mapper.Map(request, address);

        await _unitOfWork.Addresses.UpdateAsync(address);

        return _mapper.Map<AddressResponse>(address);
    }


    public async Task UpdatePasswordAsync(UpdatePasswordRequest request)
    {
        var user = await _unitOfWork.Users.FirstOrDefaultAsync(new UserById(request.UserId));
        if (user == null) throw new NotFoundException($"El usuario con Id {request.UserId} no fue encontrado.");

        var CheckPassword = _passwordHasher.VerifyHashedPassword(user, user.Password, request.CurrentPassword);
        if (CheckPassword == PasswordVerificationResult.Failed) throw new UnauthorizedException($"La contraseña actual del usuario es incorrecta");

        user.Password = _passwordHasher.HashPassword(user, request.NewPassword);
        await _unitOfWork.Users.UpdateAsync(user);

    }
}

