using Core.Entities.Persons;

namespace Core.Entities.Addresses
{
    public class Country : CatalogBase {
        public ICollection<State> States { get; set; }
    }
    public class State : CatalogBase {
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<Municipality> Municipalities { get; set; }

    }
    public class Municipality : CatalogBase   {
        public int StateId { get; set; }
        public State State { get; set; }
    }
}

