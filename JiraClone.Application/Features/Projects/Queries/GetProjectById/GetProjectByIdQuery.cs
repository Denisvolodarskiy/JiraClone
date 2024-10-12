using JiraClone.Domain.Common;
using JiraClone.Infrastructure.ReadModel;
using MediatR;

namespace JiraClone.Application.Features.Projects.Queries.GetProjectById
{
    public record GetProjectByIdQuery : IRequest<Result<ProjectReadModel>>
    {
        public required int ProjectId { get; set; }
    }
}
