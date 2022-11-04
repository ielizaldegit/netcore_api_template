using System;
using Ardalis.Specification;
using Core.Application.Common.Especifications;
using Core.Entities.Auth;
using Core.Entities.Persons;

namespace Core.Application.Profile;

public class PersonById : Specification<Person> {
    public PersonById(int PersonId) {
        Query
            .Include(u => u.PersonUsers)
            .Include(u => u.Gender)
            .Include(u => u.MaritalStatus)
            .Include(u => u.Address)
            .Where(u => u.PersonId == PersonId);
    }
}

public class AddressById : Specification<Address>
{
    public AddressById(int AddressId)
    {
        Query
            .Where(u => u.AddressId == AddressId);
    }
}







public class SearchPerson : Specification<Person>
{
    public SearchPerson(SearchPersonRequest request)

        => Query
            .Where(p => p.GenderId == request.GenderId)
            .SearchBy(request);
}
       