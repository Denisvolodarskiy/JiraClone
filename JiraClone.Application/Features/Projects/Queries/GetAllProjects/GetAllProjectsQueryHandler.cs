using JiraClone.Domain.Common;
using JiraClone.Domain.Errors;
using JiraClone.Infrastructure.DbContexts;
using JiraClone.Infrastructure.ReadModel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JiraClone.Application.Features.Projects.Queries.GetAllProjects;

public class GetAllProjectsQueryHandler(JiraCloneDbContext dbContext) : IRequestHandler<GetAllProjectsQuery, Result<List<ProjectReadModel>>>
{


    public async Task<Result<List<ProjectReadModel>>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
    {
        var projects = await dbContext.Projects
        .Select(p => new ProjectReadModel
        {
            ProjectId = p.ProjectId,
            Title = p.Title,
        })
        .ToListAsync(cancellationToken);

        if (projects?.Count == 0) return ProjectErrors.NoCreatedProjects;

        return projects;
    }
}