using JiraClone.Domain.Common;
using JiraClone.Infrastructure.DbContexts;
using JiraClone.Infrastructure.ReadModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using JiraClone.Domain.Errors;

namespace JiraClone.Application.Features.Tasks.Commands.AssignTask;

public class AssignTaskCommandHandler(JiraCloneDbContext dbContext) : IRequestHandler<AssignTaskCommand, Result<TaskReadModel>>
{




    public async Task<Result<TaskReadModel>> Handle(AssignTaskCommand request, CancellationToken cancellationToken)
    {

        var existingTask = await dbContext.Tasks.AsNoTracking().FirstOrDefaultAsync(x => x.TaskId == request.TaskId, cancellationToken);

        if (existingTask is null) return TaskErrors.TaskNotFound;
        
        var existingUser = await dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.AssignedUserId, cancellationToken);

        if (existingUser is null) return UserErrors.UserIsNotFound;
        
        existingTask.AssignedUserId = request.AssignedUserId ?? existingTask.AssignedUserId;

        dbContext.Tasks.Update(existingTask);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new TaskReadModel
        {
            TaskId = existingTask.TaskId,
            Title = existingTask.Title,
            Description = existingTask.Description,
            AssignedUserId = existingTask.AssignedUserId,
        };
    }
}
