using JiraClone.Domain.Common;
using JiraClone.Domain.Errors;
using JiraClone.Infrastructure.DbContexts;
using JiraClone.Infrastructure.ReadModels;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace JiraClone.Application.Features.Tasks.Commands.UpdateTask;

public class UpdateTaskCommandHandler(JiraCloneDbContext dbContext) : IRequestHandler<UpdateTaskCommand, Result<TaskReadModel>>
{


    public async Task<Result<TaskReadModel>> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var existingTask = await dbContext.Tasks.AsNoTracking().FirstOrDefaultAsync(x => x.TaskId == request.TaskId, cancellationToken);

        if (existingTask is null)
            return TaskErrors.TaskNotFound;
        
        existingTask.Title = !string.IsNullOrEmpty(request.Title) ? request.Title : existingTask.Title;
        existingTask.Description = !string.IsNullOrEmpty(request.Description) ? request.Description : existingTask.Description;


        if (request.AssignedUserId != existingTask.AssignedUserId )
        {
            if (request.AssignedUserId is null )
            {

                existingTask.AssignedUserId = request.AssignedUserId;
            }

            if (request.AssignedUserId.HasValue)
            {
                var existingUser = await dbContext.Users
                    .FirstOrDefaultAsync(u => u.Id == request.AssignedUserId, cancellationToken);

                if (existingUser is null) return UserErrors.UserIsNotFound;

                existingTask.AssignedUserId = request.AssignedUserId;
            }
        }

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
    //existingTask.Status = request.Status;
    //existingTask.Priority = request.Priority;
    //existingTask.DueDate = request.DueDate;
}
