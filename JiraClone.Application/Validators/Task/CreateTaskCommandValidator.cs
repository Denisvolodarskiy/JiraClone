using FluentValidation;
using JiraClone.Application.Constants;
using JiraClone.Application.Extensions;
using JiraClone.Application.Features.Tasks.Commands.CreateTask;

namespace JiraClone.Application.Validators.Task;

public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
{
    public CreateTaskCommandValidator()
    {

        RuleFor(x => x.ProjectId)
           .CannotBeNull(ApplicationConstants.Validators.ProjectId)
           .CannotBeEmpty(ApplicationConstants.Validators.ProjectId)
           .MustBeGreaterThanZero(ApplicationConstants.Validators.ProjectId);

        RuleFor(x => x.Title)
           .CannotBeNull(ApplicationConstants.Validators.Title)
           .CannotBeEmpty(ApplicationConstants.Validators.Title)
           .MustBeLengthBetween(ApplicationConstants.Validators.TitleNameMinLength, ApplicationConstants.Validators.TitleNameMaxLength, ApplicationConstants.Validators.Title);

        RuleFor(x => x.Description)
            .MaximumLength(ApplicationConstants.Validators.TaskDescriptionMaxLength).WithMessage(ApplicationConstants.Validators.TaskDescriptionMaxLengthWarningMessage);

        RuleFor(x => x.AssignedUserId)
            .MustBeValidAssignedUserGuid();
    }
}

