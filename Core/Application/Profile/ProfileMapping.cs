using Core.Entities.Persons;

namespace Core.Application.Profile;

public class ProfileMapping : AutoMapper.Profile
{
    public ProfileMapping()
    {

        CreateMap<Person, PersonResponse>()
            .ForMember(dest => dest.Gender, origen => origen.MapFrom(origen => origen.Gender.Name))
            .ForMember(dest => dest.MaritalStatus, origen => origen.MapFrom(origen => origen.MaritalStatus.Name))
            .ForMember(dest => dest.FullName, origen => origen.MapFrom(origen => (origen.Name + ' ' + origen.LastName + ' ' + origen.MiddleName).Trim()))
            .ReverseMap();
        CreateMap<Person, CreatePersonRequest>().ReverseMap();
        CreateMap<Person, UpdatePersonRequest>().ReverseMap();

        CreateMap<Address, CreateAddressRequest>().ReverseMap();
        CreateMap<Address, UpdateAddressRequest>().ReverseMap();
        CreateMap<Address, AddressResponse>().ReverseMap();
    }


}



