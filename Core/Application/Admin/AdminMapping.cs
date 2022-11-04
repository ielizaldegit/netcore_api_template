using Core.Entities.Auth;

namespace Core.Application.Admin;

public class AdminMapping : AutoMapper.Profile {
    public AdminMapping() {
        CreateMap<User, UserResponse>()
            .ForMember(dest => dest.Role, origen => origen.MapFrom(origen => origen.Role.Name))
            .ReverseMap();
        CreateMap<User, CreateUserRequest>().ReverseMap();

        
        CreateMap<Permission, PermissionResponse>()
            .ForMember(dest => dest.Parent, origen => origen.MapFrom(origen => origen.Parent.DisplayText))
            .ReverseMap();
        CreateMap<Permission, CreatePermissionRequest>().ReverseMap();
        CreateMap<Permission, UpdatePermissionRequest>().ReverseMap();


        CreateMap<Module, ModuleResponse>()
            .ForMember(dest => dest.Parent, origen => origen.MapFrom(origen => origen.Parent.Title))
            .ReverseMap();
        CreateMap<Module, CreateModuleRequest>().ReverseMap();
        CreateMap<Module, UpdateModuleRequest>().ReverseMap();



        CreateMap<Role, RoleResponse>().ReverseMap();
        CreateMap<Role, CreateRoleRequest>().ReverseMap();
        CreateMap<Role, UpdateRoleRequest>().ReverseMap();
    }
}

