using FluentValidation;

namespace Core.Application.Profile;

public class CreatePersonRequestValidator : AbstractValidator<CreatePersonRequest> {
    public CreatePersonRequestValidator() {
        RuleFor(p => p.Name).NotEmpty().MaximumLength(250);
        RuleFor(p => p.LastName).NotEmpty().MaximumLength(250);
        RuleFor(p => p.GenderId).GreaterThan(0);
        RuleFor(p => p.MaritalStatusId).GreaterThan(0);
        RuleFor(p => p.MaritalStatusId).GreaterThan(0);
        RuleFor(p => p.Email).EmailAddress();
        RuleFor(p => p.MaritalStatusId).GreaterThan(0);
    }
}

public class UpdatePersonRequestValidator : AbstractValidator<UpdatePersonRequest> {
    public UpdatePersonRequestValidator() {
        Include(new CreatePersonRequestValidator());
        RuleFor(p => p.PersonId).NotEmpty().GreaterThan(0);
    }
}



public class UpdatePasswordRequestValidator : AbstractValidator<UpdatePasswordRequest>
{
    public UpdatePasswordRequestValidator()
    {
        //RuleFor(p => p.UserId).NotEmpty().GreaterThan(0);
        RuleFor(p => p.CurrentPassword).NotNull();
        RuleFor(p => p.NewPassword).NotNull();
    }
}


