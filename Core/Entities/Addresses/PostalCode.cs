namespace Core.Entities.Addresses
{
    public class PostalCode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string SettlementType { get; set; }
        public string Settlement { get; set; }
        public int StateId { get; set; }
        public string State { get; set; }
        public int MunicipalityId { get; set; }
        public string Municipality { get; set; }
        public string City { get; set; }

    }
}

