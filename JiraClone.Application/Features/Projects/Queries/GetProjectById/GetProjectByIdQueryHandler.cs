using JiraClone.Domain.Common;
using JiraClone.Domain.Errors;
using JiraClone.Infrastructure.DbContexts;
using JiraClone.Infrastructure.ReadModel;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace JiraClone.Application.Features.Projects.Queries.GetProjectById;

public class GetProjectByIdQueryHandler(JiraCloneDbContext dbContext) : IRequestHandler<GetProjectByIdQuery, Result<ProjectReadModel>>
{


    public async Task<Result<ProjectReadModel>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        var project = await dbContext.Projects.AsNoTracking().FirstOrDefaultAsync(x => x.ProjectId == request.ProjectId, cancellationToken);

        if (project is null) return ProjectErrors.ProjectIsNotFound;

        return new ProjectReadModel
        {
            ProjectId = project.ProjectId,
            Title = project.Title,
        };
    }
}