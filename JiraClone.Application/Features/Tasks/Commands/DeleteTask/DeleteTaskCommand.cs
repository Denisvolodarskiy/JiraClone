using JiraClone.Domain.Common;
using MediatR;

namespace JiraClone.Application.Features.Tasks.Commands.DeleteTask
{
    public record DeleteTaskCommand  : IRequest<Result<bool>>
    {
        public required int TaskId { get; set; }
    }
}
