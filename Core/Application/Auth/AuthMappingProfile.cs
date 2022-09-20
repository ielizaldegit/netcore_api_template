using Core.Aplication.Auth;
using Core.Application.Profile;
using Core.Entities.Auth;
using Core.Entities.Persons;

namespace Core.Application.Auth;

public class AuthMappingProfile : AutoMapper.Profile
{
    public AuthMappingProfile()
    {
        CreateMap<User, UserDTO>()
            .ForMember(dest => dest.Role, origen => origen.MapFrom(origen => origen.Role.Name))
            .ReverseMap();
        CreateMap<User, RegisterRequestDTO>().ReverseMap();
        CreateMap<Module, ModuleDTO>().ReverseMap();
        CreateMap<Permission, PermissionDTO>().ReverseMap();
        CreateMap<Role, RoleDTO>().ReverseMap();

    }
}

