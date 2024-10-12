using FluentValidation;
using JiraClone.Application.Constants;
using JiraClone.Application.Extensions;
using JiraClone.Application.Features.Projects.Queries.GetProjectById;


namespace JiraClone.Application.Validators.Project
{
    public class GetProjectByIdQueryValidator : AbstractValidator<GetProjectByIdQuery>
    {
        public GetProjectByIdQueryValidator()
        {
            RuleFor(x => x.ProjectId)
                .CannotBeNull(ApplicationConstants.Validators.ProjectId)
                .CannotBeEmpty(ApplicationConstants.Validators.ProjectId)
                .MustBeGreaterThanZero(ApplicationConstants.Validators.ProjectId);
        }
    }
}