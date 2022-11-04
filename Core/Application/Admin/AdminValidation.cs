using Core.Application.Profile;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Core.Application.Admin;



public class CreatePermissionRequestValidator : AbstractValidator<CreatePermissionRequest> {
    public CreatePermissionRequestValidator() {
        RuleFor(p => p.Name).NotEmpty().MaximumLength(250);
        RuleFor(p => p.DisplayText).NotEmpty().MaximumLength(250);
    }
}
public class UpdatePermissionRequestValidator : AbstractValidator<UpdatePermissionRequest> {
    public UpdatePermissionRequestValidator() {
        Include(new CreatePermissionRequestValidator());
        RuleFor(p => p.PermissionId).NotEmpty().GreaterThan(0);
    }
}


public class CreateModuleRequestValidator : AbstractValidator<CreateModuleRequest> {
    public CreateModuleRequestValidator() {
        RuleFor(p => p.Name).NotEmpty().MaximumLength(250);
        RuleFor(p => p.Title).NotEmpty().MaximumLength(250);
    }
}
public class UpdateModuleRequestValidator : AbstractValidator<UpdateModuleRequest> {
    public UpdateModuleRequestValidator() {
        Include(new CreateModuleRequestValidator());
        RuleFor(p => p.ModuleId).NotEmpty().GreaterThan(0);
    }
}
public class UpdateModulePermissionRequestValidator : AbstractValidator<UpdateModulePermissionRequest> {
    public UpdateModulePermissionRequestValidator() {

        RuleFor(x => x.Ids).Cascade(CascadeMode.Stop)
            .NotNull()
            .Custom((list, context) => {
                var duplicates = list.GroupBy(x => x).Where(g => g.Count() > 1).Select(y => y.Key).ToList();
                if (duplicates.Count > 0){
                    context.AddFailure($"Existen valores duplicados en el campo 'PermissionIds' [{ string.Join(",", duplicates) }]");
            }
        });


    }
}


public class CreateRoleRequestValidator : AbstractValidator<CreateRoleRequest> {
    public CreateRoleRequestValidator()  {
        RuleFor(p => p.Name).NotEmpty().MaximumLength(250);
    }
}
public class UpdateRoleRequestValidator : AbstractValidator<UpdateRoleRequest> {
    public UpdateRoleRequestValidator() {
        Include(new CreateRoleRequestValidator());
        RuleFor(p => p.RoleId).NotEmpty().GreaterThan(0);
    }
}