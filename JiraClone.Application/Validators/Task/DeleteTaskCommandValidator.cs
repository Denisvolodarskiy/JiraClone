using FluentValidation;
using JiraClone.Application.Constants;
using JiraClone.Application.Extensions;
using JiraClone.Application.Features.Tasks.Commands.DeleteTask;

namespace JiraClone.Application.Validators.Task;

public class DeleteTaskCommandValidator : AbstractValidator<DeleteTaskCommand>
{
    public DeleteTaskCommandValidator()
    {
        RuleFor(x => x.TaskId)
           .CannotBeNull(ApplicationConstants.Validators.TaskId)
           .CannotBeEmpty(ApplicationConstants.Validators.TaskId)
           .MustBeGreaterThanZero(ApplicationConstants.Validators.TaskId);
    }
}
