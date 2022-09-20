using System.ComponentModel.DataAnnotations;

namespace Core.Application.Profile
{
    public class PersonRequestDTO
    {
        [Required(ErrorMessage = "El Id de la persona es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El Id de la persona no es válido")]
        public int PersonId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El nombre de la persona es requerido")]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El apellido de la persona es requerido")]
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "El Id del género no es válido")]
        public int? GenderId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "El Id del estado civil no es válido")]
        public int? MaritalStatusId { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? Title { get; set; }
        public string? Email { get; set; }
        public string? HomePhone { get; set; }
        public string? MobilePhone { get; set; }
        public string? OfficePhone { get; set; }
        public string? Rfc { get; set; }
        public string? Curp { get; set; }
        public string? Photo { get; set; }
        public string? PhotoBase64 { get; set; }
    }

    public class PersonDTO {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int GenderId { get; set; }
        public string Gender { get; set; }
        public int MaritalStatusId { get; set; }
        public string MaritalStatus { get; set; }
        public int AddressId { get; set; }
        public AddressDTO Address { get; set; }
        public DateTime Birthdate { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string OfficePhone { get; set; }
        public string Rfc { get; set; }
        public string Curp { get; set; }
        public string Photo { get; set; }
    }

    public class AddressDTO {
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

    }

}

