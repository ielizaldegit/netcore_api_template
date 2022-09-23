using Core.Aplication.Auth;
using Core.Entities.Auth;

namespace Core.Application.Auth;

public class AuthMapping : AutoMapper.Profile
{
    public AuthMapping()
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

