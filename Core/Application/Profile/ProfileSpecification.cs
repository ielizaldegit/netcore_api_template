using System;
using Ardalis.Specification;
using Core.Entities.Auth;
using Core.Entities.Persons;

namespace Core.Application.Profile {

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
}

