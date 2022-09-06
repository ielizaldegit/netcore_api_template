namespace Core.Entities.Persons
{
    public class Address : AuditBaseEntity
    {
        public int AddressId { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Municipality { get; set; }
        public string City { get; set; }
        public string Settlement { get; set; }
        public string Street { get; set; }
        public string ExteriorNumber { get; set; }
        public string InteriorNumber { get; set; }
        public string Reference { get; set; }
        public string PostalCode { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }

        public ICollection<Person> Persons { get; set; }
    }
}

