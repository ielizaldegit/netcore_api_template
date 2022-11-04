using Core.Domain.Entities.Mail;
using Core.Entities.Persons;

namespace Core.Entities.Auth;

public class User: AuditBaseEntity
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public int RoleId { get; set; }
    public bool EmailConfirmed { get; set; }
    public bool IsTemporaryPassword { get; set; }
    public bool IsActive { get; set; }
    public Role Role { get; set; }

    public ICollection<ModuleUser> ModuleUsers { get; set; }
    public ICollection<PersonUser> PersonUsers { get; set; }

    public ICollection<Activation> Activations { get; set; }

}


