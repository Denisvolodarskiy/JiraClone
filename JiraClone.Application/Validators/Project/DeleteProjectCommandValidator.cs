using FluentValidation;
using JiraClone.Application.Constants;
using JiraClone.Application.Extensions;
using JiraClone.Application.Features.Projects.Commands.DeleteProject;

namespace JiraClone.Application.Validators.Project;

public class DeleteProjectCommandValidator : AbstractValidator<DeleteProjectCommand>
{
    public DeleteProjectCommandValidator()
    {
        RuleFor(x => x.ProjectId)
           .CannotBeNull(ApplicationConstants.Validators.ProjectId)
           .CannotBeEmpty(ApplicationConstants.Validators.ProjectId)
           .MustBeGreaterThanZero(ApplicationConstants.Validators.ProjectId);
    }
}