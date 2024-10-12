using JiraClone.Domain.Common;
using JiraClone.Domain.Errors;
using JiraClone.Infrastructure.DbContexts;
using JiraClone.Infrastructure.ReadModel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JiraClone.Application.Features.Projects.Commands.UpdateProject;

public class UpdateProjectCommandHandler(JiraCloneDbContext dbContext) : IRequestHandler<UpdateProjectCommand, Result<ProjectReadModel>>
{

    public async Task<Result<ProjectReadModel>> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await dbContext.Projects.Where(x => x.ProjectId == request.ProjectId).FirstOrDefaultAsync(cancellationToken);

        if (project is null) return ProjectErrors.ProjectIsNotFound;

        project.UpdateTitle(request.Title);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new ProjectReadModel
        {
            ProjectId = project.ProjectId, 
            Title = project.Title
        };
    }
}