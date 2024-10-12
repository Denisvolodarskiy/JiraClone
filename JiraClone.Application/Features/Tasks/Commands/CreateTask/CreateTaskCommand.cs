using JiraClone.Domain.Common;
using JiraClone.Infrastructure.ReadModels;
using MediatR;

namespace JiraClone.Application.Features.Tasks.Commands.CreateTask;

public record CreateTaskCommand : IRequest<Result<TaskReadModel>>
{
    public required int ProjectId { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; } = string.Empty;
    public Guid? AssignedUserId { get; set; } = Guid.Empty;
}
