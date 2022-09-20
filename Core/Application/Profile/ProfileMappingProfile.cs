using System;
using Core.Aplication.Auth;
using Core.Entities.Auth;
using Core.Entities.Persons;

namespace Core.Application.Profile;

public class ProfileMappingProfile : AutoMapper.Profile
{
    public ProfileMappingProfile()
    {

        CreateMap<Person, PersonDTO>()
            .ForMember(dest => dest.Gender, origen => origen.MapFrom(origen => origen.Gender.Name))
            .ForMember(dest => dest.MaritalStatus, origen => origen.MapFrom(origen => origen.MaritalStatus.Name))
            .ReverseMap();

        CreateMap<Person, PersonRequestDTO>().ReverseMap();
        CreateMap<Address, AddressDTO>().ReverseMap();


    }
}



