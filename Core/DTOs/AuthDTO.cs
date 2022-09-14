using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Core.DTOs
{
    public class LoginRequestDTO {
        [Required(AllowEmptyStrings = false, ErrorMessage = "El nombre del usuario es requerido")]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "La contraseña del usuario es requerida")]
        public string Password { get; set; }
    }

    public class RegisterRequestDTO {
        [Required(ErrorMessage = "El nombre del usuario es requerido")]
        public string Name { get; set; }
        [Required(ErrorMessage = "La contraseña del usuario es requerida")]
        public string Password { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }

        [JsonIgnore]
        public int? ModifiedBy { get; set; }
        [JsonIgnore]
        public int? CreatedBy { get; set; }
        [JsonIgnore]
        public DateTime? CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime? ModifiedAt { get; set; }
    }


    public class UserDTO {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool IsActive { get; set; }

        public IEnumerable<PersonDTO> Persons { get; set; }
        public IEnumerable<ModuleDTO> Modules { get; set; }
    }


    public class ModuleDTO {
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public string Route { get; set; }
        public string CssClass { get; set; }
        public int? DisplayOrder { get; set; }
        public bool? IsVisible { get; set; }
        public bool? IsActive { get; set; }
        public int? ParentId { get; set; }

        public ICollection<ModuleDTO> Children { get; set; }
        public ICollection<PermissionDTO> Permissions { get; set; }
    }



    public class PermissionDTO {
        public int PermissionId { get; set; }
        public string Name { get; set; }
        public string DisplayText { get; set; }
        public string CssClass { get; set; }
        public string Description { get; set; }
        public bool? Grouping { get; set; }
        public int? DisplayOrder { get; set; }
        public bool? IsVisible { get; set; }
        public bool? IsActive { get; set; }
        public int? ParentId { get; set; }

    }

    public class RoleDTO {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }




}

