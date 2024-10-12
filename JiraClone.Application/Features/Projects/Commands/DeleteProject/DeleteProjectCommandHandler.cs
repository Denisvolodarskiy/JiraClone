using JiraClone.Domain.Common;
using JiraClone.Domain.Entities;
using JiraClone.Domain.Errors;
using JiraClone.Infrastructure.DbContexts;
using JiraClone.Infrastructure.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace JiraClone.Application.Features.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler(JiraCloneDbContext dbContext, ICacheHelper cacheHelper) : IRequestHandler<DeleteProjectCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(DeleteProjectCommand request, CancellationToken ct)
        {

            var cacheKey = $"Project{request.ProjectId}";
            var cachedProjects = await cacheHelper.TryGetAsync<Project>(cacheKey, ct);

            if (cachedProjects is not null)
            {
                await cacheHelper.RemoveAsync(cacheKey, ct);
            }

            var project = await dbContext.Projects.AsNoTracking().Where(x => x.ProjectId == request.ProjectId).FirstOrDefaultAsync(ct);

            if (project is null) return ProjectErrors.ProjectIsNotFound;

            dbContext.Projects.Remove(project);
            await dbContext.SaveChangesAsync(ct);

            return true; 
        }
    }
}