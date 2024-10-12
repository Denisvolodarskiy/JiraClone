using JiraClone.Domain.Common;
using JiraClone.Domain.Errors;
using JiraClone.Infrastructure.DbContexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JiraClone.Application.Features.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommandHandler(JiraCloneDbContext dbContext) : IRequestHandler<DeleteTaskCommand, Result<bool>>
    {

        public async Task<Result<bool>> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var existingTask = await dbContext.Tasks.AsNoTracking().FirstOrDefaultAsync(x => x.TaskId == request.TaskId, cancellationToken);

            if (existingTask is null) 
                return TaskErrors.TaskNotFound;

            dbContext.Tasks.Remove(existingTask);
            await dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}