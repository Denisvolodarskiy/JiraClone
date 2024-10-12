using JiraClone.Domain.Common;
using JiraClone.Infrastructure.ReadModels;
using MediatR;

namespace JiraClone.Application.Features.Users.Commands.CreateUser
{
    public record CreateUserCommand : IRequest<Result<UserReadModel>>
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }
    }
}
