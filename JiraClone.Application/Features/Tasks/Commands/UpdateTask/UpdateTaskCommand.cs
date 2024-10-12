using JiraClone.Domain.Common;
using JiraClone.Infrastructure.ReadModels;
using MediatR;


namespace JiraClone.Application.Features.Tasks.Commands.UpdateTask;

public record UpdateTaskCommand : IRequest<Result<TaskReadModel>>
{
    public required int TaskId { get; set; }
    public string? Title { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public Guid? AssignedUserId { get; set; } = Guid.Empty;
}
