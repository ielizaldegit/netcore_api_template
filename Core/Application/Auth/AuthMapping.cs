using Core.Entities.Auth;

namespace Core.Application.Auth;

public class AuthMapping : AutoMapper.Profile {

    public AuthMapping() {
        CreateMap<User, LoginResponse>()
            .ForMember(dest => dest.Role, origen => origen.MapFrom(origen => origen.Role.Name))
            .ReverseMap();
        CreateMap<User, RegisterRequest>().ReverseMap();

    }
}

