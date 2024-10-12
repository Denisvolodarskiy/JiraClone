using JiraClone.Domain.Common;
using JiraClone.Domain.Errors;
using JiraClone.Infrastructure.DbContexts;
using JiraClone.Infrastructure.ReadModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Task = JiraClone.Domain.Entities.Task;


namespace JiraClone.Application.Features.Tasks.Commands.CreateTask;

public class CreateTaskCommandHandler(JiraCloneDbContext dbContext) : IRequestHandler<CreateTaskCommand, Result<TaskReadModel>>
{

    public async Task<Result<TaskReadModel>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {

        var existingProject = await dbContext.Projects.Where(x => x.ProjectId == request.ProjectId).FirstOrDefaultAsync(cancellationToken);

        if (existingProject is null) 
            return ProjectErrors.ProjectIsNotFound;
        
        if (existingProject.Tasks.Any(pt => pt.Title == request.Title)) 
            return TaskErrors.TaskWithTitleAlreadyExist;
        
        if (request.AssignedUserId.HasValue)
        {
            var existingUser = await dbContext.Users
                .FirstOrDefaultAsync(u => u.Id == request.AssignedUserId, cancellationToken);

            if (existingUser is null) 
                return UserErrors.UserIsNotFound;
        }

        var newTask = new Task()
        {
            Title = request.Title,
            Description = request.Description, // Status = task.Status,// Priority = task.Priority, //DueDate = task.DueDate,
            AssignedUserId = request.AssignedUserId,
        };

        existingProject.Tasks.Add(newTask);
        await dbContext.Tasks.AddAsync(newTask, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new TaskReadModel()
        {
            TaskId = newTask.TaskId,
            Title = request.Title,
            Description = newTask.Description,
            AssignedUserId = newTask.AssignedUserId,
        };
    }
}
