using FluentValidation;
using JiraClone.Application.Constants;
using JiraClone.Application.Extensions;
using JiraClone.Application.Features.Tasks.Commands.AssignTask;

namespace JiraClone.Application.Validators.Task;

public class AssignTaskCommandValidator : AbstractValidator<AssignTaskCommand>
{
    public AssignTaskCommandValidator()
    {
        RuleFor(x => x.TaskId)
          .CannotBeNull(ApplicationConstants.Validators.TaskId)
          .CannotBeEmpty(ApplicationConstants.Validators.TaskId)
          .MustBeGreaterThanZero(ApplicationConstants.Validators.TaskId);

        RuleFor(x => x.AssignedUserId)
            .MustBeValidAssignedUserGuid();
    }
}