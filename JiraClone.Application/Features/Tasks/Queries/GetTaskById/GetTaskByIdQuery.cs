using JiraClone.Domain.Common;
using JiraClone.Infrastructure.ReadModels;
using MediatR;

namespace JiraClone.Application.Features.Tasks.Queries.GetTaskById
{
    public record GetTaskByIdQuery : IRequest<Result<TaskReadModel>>
    {
        public required int TaskId { get; set; }
    }
}
