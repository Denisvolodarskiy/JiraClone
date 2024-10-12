using FluentValidation;
using JiraClone.Application.Constants;
using JiraClone.Application.Extensions;
using JiraClone.Application.Features.Projects.Commands.UpdateProject;

namespace JiraClone.Application.Validators.Project;

public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
{
    public UpdateProjectCommandValidator()
    {
        RuleFor(x => x.Title)
          .CannotBeNull(ApplicationConstants.Validators.Title)
          .CannotBeEmpty(ApplicationConstants.Validators.Title)
          .MustBeLengthBetween(ApplicationConstants.Validators.TitleNameMinLength, ApplicationConstants.Validators.TitleNameMaxLength, ApplicationConstants.Validators.Title);

        RuleFor(x => x.ProjectId)
                .CannotBeNull(ApplicationConstants.Validators.ProjectId)
                .CannotBeEmpty(ApplicationConstants.Validators.ProjectId)
                .MustBeGreaterThanZero(ApplicationConstants.Validators.ProjectId);

    }
}
