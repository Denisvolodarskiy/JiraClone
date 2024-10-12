using FluentValidation;
using JiraClone.Application.Constants;
using JiraClone.Application.Extensions;
using JiraClone.Application.Features.Users.Commands.CreateUser;

namespace JiraClone.Application.Validators.User;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Email)
           .CannotBeNull(ApplicationConstants.Validators.Email)
           .CannotBeEmpty(ApplicationConstants.Validators.Email)
           .MustBeValidEmail();
           
        RuleFor(x => x.Password)
            .CannotBeNull(ApplicationConstants.Validators.Password)
            .CannotBeEmpty(ApplicationConstants.Validators.Password)
            .MinimumLength(ApplicationConstants.Validators.PasswordMinLength).WithMessage($"{ApplicationConstants.Validators.Password} must be at least 6 characters long.");

        RuleFor(x => x.Role)
            .CannotBeNull(ApplicationConstants.Validators.Role)
            .CannotBeEmpty(ApplicationConstants.Validators.Role)
            .Must(role => ApplicationConstants.Roles.RoleNames.Contains(role)).WithMessage($"{Constants.ApplicationConstants.Validators.Role} is invalid.");
    }
}
