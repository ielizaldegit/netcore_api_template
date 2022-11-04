using Core.Entities.Auth;

namespace Core.Entities.Persons
{
    public class Person : AuditBaseEntity
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int? GenderId { get; set; }
        public int? AddressId { get; set; }
        public int? MaritalStatusId { get; set; }
        public DateTime Birthdate { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string OfficePhone { get; set; }
        public string Rfc { get; set; }
        public string Curp { get; set; }
        public string Photo { get; set; }
        public Address Address { get; set; }

        public Gender Gender { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public ICollection<PersonUser> PersonUsers { get; set; }
    }

    public class PersonUser
    {
        public int PersonId { get; set; }
        public int UserId { get; set; }
        public int? RelationshipId { get; set; }
        public bool? Principal { get; set; }

        public Relationship Relationship { get; set; }
        public Person Person { get; set; }
        public User User { get; set; }

    }


}

