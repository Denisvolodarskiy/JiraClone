using FluentValidation;
using JiraClone.Application.Constants;
using JiraClone.Application.Extensions;
using JiraClone.Application.Features.Users.Commands.LoginUser;

namespace JiraClone.Application.Validators.User;

public class LogInUserCommandValidator : AbstractValidator<LogInUserCommand>
{
    public LogInUserCommandValidator()
    {
        RuleFor(x => x.Email)
           .CannotBeNull(ApplicationConstants.Validators.Email)
           .CannotBeEmpty(ApplicationConstants.Validators.Email)
           .MustBeValidEmail();

        RuleFor(x => x.Password)
            .CannotBeNull(ApplicationConstants.Validators.Password)
            .CannotBeEmpty(ApplicationConstants.Validators.Password)
            .MinimumLength(ApplicationConstants.Validators.PasswordMinLength).WithMessage($"{ApplicationConstants.Validators.Password} must be at least 6 characters long.");
    }
}

