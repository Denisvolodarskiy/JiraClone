using JiraClone.Domain.Common;
using JiraClone.Infrastructure.ReadModels;
using MediatR;

namespace JiraClone.Application.Features.Tasks.Commands.AssignTask;

public record AssignTaskCommand : IRequest<Result<TaskReadModel>>
{
    public required int TaskId { get; set; }
    public Guid? AssignedUserId { get; set; }
}
