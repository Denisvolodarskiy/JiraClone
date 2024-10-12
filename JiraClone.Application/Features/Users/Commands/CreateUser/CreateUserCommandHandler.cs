using JiraClone.Domain.Common;
using JiraClone.Domain.Entities.ApplicationUser;
using JiraClone.Domain.Errors;
using JiraClone.Infrastructure.DbContexts;
using JiraClone.Infrastructure.ReadModels;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace JiraClone.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandHandler(UserManager<User> userManager) : IRequestHandler<CreateUserCommand, Result<UserReadModel>>
{



    public async Task<Result<UserReadModel>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            UserName = request.Email,
            Email = request.Email,
            Role = request.Role,
        };

        var result = await userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded) return UserErrors.UserIsNotCreated;

        await userManager.AddToRoleAsync(user, user.Role);

        return new UserReadModel()
        {
            UserId = user.Id,
        };
    }
}
