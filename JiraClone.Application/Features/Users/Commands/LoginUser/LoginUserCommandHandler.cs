using JiraClone.Domain.Common;
using JiraClone.Domain.Entities.ApplicationUser;
using JiraClone.Infrastructure.Helpers;
using JiraClone.Infrastructure.ReadModels;
using MediatR;
using Microsoft.AspNetCore.Identity;
using JiraClone.Domain.Errors;

namespace JiraClone.Application.Features.Users.Commands.LoginUser;

public class LoginUserCommandHandler(UserManager<User> userManager, IJwtHelper jwtHelper) : IRequestHandler<LogInUserCommand, Result<UserReadModel>>
{


    public async Task<Result<UserReadModel>> Handle(LogInUserCommand request, CancellationToken cancellationToken)
    {

        var user = await userManager.FindByEmailAsync(request.Email);
        if (user is null) return UserErrors.UserIsNotFound;

        var userCheck = await userManager.CheckPasswordAsync(user, request.Password);

        if (userCheck is false) return UserErrors.UserIsNotValid;

        var token = jwtHelper.GenerateToken(user);
        if (!token.IsSuccess || token.Value is null) return JwtErrors.TokenIsNotCreated;
        
        var userReadModel = new UserReadModel
        {
            UserId = user.Id,
            BearerToken = token.Value
        };

        return userReadModel;
    }
}
