using JiraClone.Domain.Common;
using JiraClone.Infrastructure.ReadModel;
using MediatR;

namespace JiraClone.Application.Features.Projects.Commands.CreateProject;

public record CreateProjectCommand : IRequest<Result<ProjectReadModel>>
{
    public required string Title { get; set; }
}