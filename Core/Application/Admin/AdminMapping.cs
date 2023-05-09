using Core.Application.Profile;
using Core.Entities.Auth;
using Core.Entities.Persons;

namespace Core.Application.Admin;

public class AdminMapping : AutoMapper.Profile {
    public AdminMapping() {
        CreateMap<User, UserResponse>()
            .ForMember(dest => dest.Role, origen => origen.MapFrom(origen => origen.Role.Name))
            .ForMember(dest => dest.Profile, origen => origen.MapFrom(origen => origen.PersonUsers.Where(x => x.Principal == true).FirstOrDefault().Person ))
            .ReverseMap();
        CreateMap<User, CreateUserRequest>().ReverseMap();





        CreateMap<Permission, PermissionResponse>()
            .ForMember(dest => dest.Parent, origen => origen.MapFrom(origen => origen.Parent.DisplayText))
            .ReverseMap();
        CreateMap<Permission, CreatePermissionRequest>().ReverseMap();
        CreateMap<Permission, UpdatePermissionRequest>().ReverseMap();


        CreateMap<Module, ModuleResponse>()
            .ForMember(dest => dest.Parent, origen => origen.MapFrom(origen => origen.Parent.Title))
            .ForMember(dest => dest.Permissions, origen => origen.MapFrom(origen => origen.ModulePermissions.Select(x => x.Permission).ToList()))
            .ReverseMap();
        CreateMap<Module, CreateModuleRequest>().ReverseMap();
        CreateMap<Module, UpdateModuleRequest>().ReverseMap();



        CreateMap<Role, RoleResponse>().ReverseMap();
        CreateMap<Role, CreateRoleRequest>().ReverseMap();
        CreateMap<Role, UpdateRoleRequest>().ReverseMap();
    }
}

