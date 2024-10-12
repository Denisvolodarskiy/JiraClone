using JiraClone.Domain.Common;
using JiraClone.Domain.Entities;
using JiraClone.Domain.Errors;
using JiraClone.Infrastructure.DbContexts;
using JiraClone.Infrastructure.Helpers;
using JiraClone.Infrastructure.ReadModel;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace JiraClone.Application.Features.Projects.Commands.CreateProject;

public class CreateProjectCommandHandler(JiraCloneDbContext dbContext, ICacheHelper cacheHelper) : IRequestHandler<CreateProjectCommand, Result<ProjectReadModel>>
{

    public async Task<Result<ProjectReadModel>> Handle(CreateProjectCommand request, CancellationToken ct)
    {
        
        var cacheKey = $"Project_{request.Title}";
        var cachedProject = await cacheHelper.TryGetAsync<Project>(cacheKey, ct);

        if (cachedProject != null)
            return ProjectErrors.ProjectWithTitleAlreadyExist;
        

        var existedProject = await dbContext.Projects.Where(x => x.Title == request.Title).AsNoTracking().FirstOrDefaultAsync(ct);

        if (existedProject is not null) 
            return ProjectErrors.ProjectWithTitleAlreadyExist;

        var project = new Project(request.Title);
        var id = project.ProjectId;

        if (project is null) 
            return ProjectErrors.ProjectIsNotCreated;

        await cacheHelper.AddAsync(cacheKey, project, ct);
        
        await dbContext.Projects.AddAsync(project, ct);
        await dbContext.SaveChangesAsync(ct);

        return new ProjectReadModel
        {
            ProjectId = project.ProjectId,
            Title = project.Title
        };
    }
}