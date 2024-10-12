using FluentValidation;
using JiraClone.Application.Constants;
using JiraClone.Application.Extensions;
using JiraClone.Application.Features.Tasks.Commands.UpdateTask;


namespace JiraClone.Application.Validators.Task;

public class UpdateTaskCommandValidator : AbstractValidator<UpdateTaskCommand>
{
    public UpdateTaskCommandValidator()
    {
        RuleFor(x => x.TaskId)
           .CannotBeNull(ApplicationConstants.Validators.TaskId)
           .CannotBeEmpty(ApplicationConstants.Validators.TaskId)
           .MustBeGreaterThanZero(ApplicationConstants.Validators.TaskId);


        RuleFor(x => x.Title)
           .MaximumLength(ApplicationConstants.Validators.TitleNameMaxLength);
           
        RuleFor(x => x.Description)
            .MaximumLength(ApplicationConstants.Validators.TaskDescriptionMaxLength).WithMessage(ApplicationConstants.Validators.TaskDescriptionMaxLengthWarningMessage);

        RuleFor(x => x.AssignedUserId)
            .MustBeValidAssignedUserGuid();
    }
}
