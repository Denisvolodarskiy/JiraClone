using FluentValidation;
using JiraClone.Application.Constants;
using JiraClone.Application.Extensions;
using JiraClone.Application.Features.Projects.Commands.CreateProject;


namespace JiraClone.Application.Validators.Project;

public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectCommandValidator()
    {
        RuleFor(x => x.Title)
           .CannotBeNull(ApplicationConstants.Validators.Title)
           .CannotBeEmpty(ApplicationConstants.Validators.Title)
           .MustBeLengthBetween(ApplicationConstants.Validators.TitleNameMinLength, ApplicationConstants.Validators.TitleNameMaxLength, ApplicationConstants.Validators.Title);
    }
}