using JiraClone.Domain.Common;
using JiraClone.Infrastructure.DbContexts;
using JiraClone.Infrastructure.ReadModels;
using MediatR;
using JiraClone.Domain.Errors;
using Microsoft.EntityFrameworkCore;


namespace JiraClone.Application.Features.Tasks.Queries.GetTaskById;

public class GetTaskByIdQueryHandler(JiraCloneDbContext dbContext) : IRequestHandler<GetTaskByIdQuery, Result<TaskReadModel>>
{

    public async Task<Result<TaskReadModel>> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        var task = await dbContext.Tasks.AsNoTracking().FirstOrDefaultAsync(x => x.TaskId == request.TaskId, cancellationToken);

        if (task is null)
            return TaskErrors.TaskNotFound;
        
        return new TaskReadModel()
        {
            TaskId = task.TaskId,
            Title = task.Title,
            Description = task.Description,
            AssignedUserId = task.AssignedUserId
        };
    }
}