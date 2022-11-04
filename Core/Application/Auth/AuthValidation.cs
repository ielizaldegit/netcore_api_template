using FluentValidation;

namespace Core.Application.Auth;

public class LoginRequestValidator : AbstractValidator<LoginRequest> {
    public LoginRequestValidator() {
        RuleFor(p => p.Name).NotNull();
        RuleFor(p => p.Password).NotNull();
    }

}

public class RegisterRequestValidator : AbstractValidator<RegisterRequest> {
    public RegisterRequestValidator() {
        RuleFor(p => p.Name).NotNull().EmailAddress().MaximumLength(250);
        RuleFor(p => p.Password).NotNull().MaximumLength(100);
    }
}

public class NewPasswordRequestValidator : AbstractValidator<NewPasswordRequest>
{
    public NewPasswordRequestValidator()
    {
        RuleFor(p => p.NewPassword).NotEmpty();
        RuleFor(p => p.ActivationId).NotEmpty();
    }
}


