using JiraClone.Domain.Common;
using JiraClone.Infrastructure.ReadModels;
using MediatR;


namespace JiraClone.Application.Features.Users.Commands.LoginUser;

public record LogInUserCommand : IRequest<Result<UserReadModel>>
{
    public required string Email { get; set; }
    public required string Password { get; set; }

}
