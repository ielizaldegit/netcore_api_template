using Core.Entities.Auth;
using Core.Entities.Persons;

namespace Core.Domain.Entities.Mail;

public class Activation
{
    public Guid ActivationId { get; set; }
    public DateTime Expiration { get; set; }
    public bool IsActive { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

}

