using JiraClone.Domain.Common;
using MediatR;

namespace JiraClone.Application.Features.Projects.Commands.DeleteProject;

public record DeleteProjectCommand : IRequest<Result<bool>>
{
    public required int ProjectId { get; set; }
}