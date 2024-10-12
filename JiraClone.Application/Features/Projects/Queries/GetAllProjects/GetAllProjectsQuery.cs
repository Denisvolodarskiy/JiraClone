using JiraClone.Domain.Common;
using JiraClone.Infrastructure.ReadModel;
using MediatR;

namespace JiraClone.Application.Features.Projects.Queries.GetAllProjects;

public record GetAllProjectsQuery : IRequest<Result<List<ProjectReadModel>>>
{
}
