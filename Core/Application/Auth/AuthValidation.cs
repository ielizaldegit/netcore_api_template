using Core.Aplication.Auth;
using FluentValidation;

namespace Core.Application.Auth
{
    public class LoginRequestDTOValidator : AbstractValidator<LoginRequestDTO> {
        public LoginRequestDTOValidator() {
            RuleFor(p => p.Name).NotNull();
            RuleFor(p => p.Password).NotNull();
        }

    }

    public class RegisterRequestDTOValidator : AbstractValidator<RegisterRequestDTO> {
        public RegisterRequestDTOValidator() {
            RuleFor(p => p.Name).NotNull().EmailAddress().MaximumLength(250);
            RuleFor(p => p.Password).NotNull().MaximumLength(100);
        }
    }
}

