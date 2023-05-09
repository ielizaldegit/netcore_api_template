using System.ComponentModel.DataAnnotations;
using Core.Application.Common.Models;

namespace Core.Application.Profile;

public class CreatePersonRequest {
    public string Name { get; set; }
    public string LastName { get; set; }
    public string? MiddleName { get; set; }
    public int? GenderId { get; set; }
    public int? MaritalStatusId { get; set; }
    public DateTime? Birthdate { get; set; }
    public string? Title { get; set; }
    public string? Email { get; set; }
    public string? HomePhone { get; set; }
    public string? MobilePhone { get; set; }
    public string? OfficePhone { get; set; }
    public string? Rfc { get; set; }
    public string? Curp { get; set; }
}
public class UpdatePersonRequest : CreatePersonRequest {
    public int PersonId { get; set; }
}
public class PersonResponse : UpdatePersonRequest {
    public AddressResponse Address { get; set; }
    public string Gender { get; set; }
    public string MaritalStatus { get; set; }
    public string Relationship { get; set; }
    public bool? Principal { get; set; }
    public string Photo { get; set; }
    public string FullName { get; set; }

}


public class PhotoRequest {
    public int PersonId { get; set; }
    public FileUploadRequest Photo { get; set; }
}
public class PhotoResponse{
    public int PersonId { get; set; }
    public string PhotoUrl { get; set; }
}


public class CreateAddressRequest {
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
public class UpdateAddressRequest : CreateAddressRequest {
    public int AddressId { get; set; }
}
public class AddressResponse : UpdateAddressRequest {
}


public class UpdatePasswordRequest
{
    //public int UserId { get; set; }
    public string NewPassword { get; set; }
    public string CurrentPassword { get; set; }
}



public class SearchPersonRequest : BaseFilter
{
    public int GenderId { get; set; }
}



