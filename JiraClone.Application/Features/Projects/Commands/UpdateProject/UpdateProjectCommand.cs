using JiraClone.Domain.Common;
using JiraClone.Infrastructure.ReadModel;
using MediatR;

namespace JiraClone.Application.Features.Projects.Commands.UpdateProject;

public record UpdateProjectCommand : IRequest<Result<ProjectReadModel>>
{
    public required int ProjectId { get; set; }
    public required string Title { get; set; }
}
