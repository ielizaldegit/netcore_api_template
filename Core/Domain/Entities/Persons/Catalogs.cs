namespace Core.Entities.Persons
{

    public class Gender: CatalogBase
    {
        public ICollection<Person> Persons { get; set; }
    }

    public class MaritalStatus : CatalogBase
    {
        public ICollection<Person> Persons { get; set; }
    }

}

