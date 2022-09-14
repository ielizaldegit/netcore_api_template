using AutoMapper;
using Core.DTOs;
using Core.Entities.Auth;
using Core.Entities.Persons;

namespace API.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {

        CreateMap<User, UserDTO>()
            .ForMember(dest => dest.Role, origen => origen.MapFrom(origen => origen.Role.Name))
            .ReverseMap();
        CreateMap<User, RegisterRequestDTO>().ReverseMap();
        CreateMap<Person, PersonDTO>()
            .ForMember(dest => dest.Gender, origen => origen.MapFrom(origen => origen.Gender.Name))
            .ForMember(dest => dest.MaritalStatus, origen => origen.MapFrom(origen => origen.MaritalStatus.Name))
            .ReverseMap();
        CreateMap<Address, AddressDTO>().ReverseMap();
        CreateMap<Module, ModuleDTO>().ReverseMap();
        CreateMap<Permission, PermissionDTO>().ReverseMap();
        CreateMap<Role, RoleDTO>().ReverseMap();

    }
}


