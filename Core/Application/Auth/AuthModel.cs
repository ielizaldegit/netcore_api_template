using Core.Application.Admin;
using Core.Application.Profile;

namespace Core.Application.Auth
{
    public class LoginRequest {
        public string Name { get; set; }
        public string Password { get; set; }
    }

    public class RegisterRequest
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
    }

    public class NewPasswordRequest
    {
        public string NewPassword { get; set; }
        public string ActivationId { get; set; }
    }


    public class LoginResponse {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool IsActive { get; set; }

        public PersonResponse Profile { get; set; }
        public IEnumerable<ModuleResponse> Modules { get; set; }
    }






}

