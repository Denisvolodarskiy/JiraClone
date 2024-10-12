using JiraClone.Domain.Common;
using JiraClone.Domain.Entities.ApplicationUser;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JiraClone.Infrastructure.Options;

namespace JiraClone.Infrastructure.Helpers;
public class JwtHelper(JwtOptions jwtOptions) : IJwtHelper
{
    
    public Result<string> GenerateToken(User user)
    {

        var claims = new[]
        {
                new Claim(Constants.Constants.Authentication.UserId, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role),
            };

        var signingCredentials = new SigningCredentials(
           new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey)),
           SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(jwtOptions.Expires),
            audience: jwtOptions.Audience,
            issuer: jwtOptions.Issuer,
            signingCredentials: signingCredentials);

        var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

        if (tokenValue is null) return new ResultError("Error occurred while trying to create JWT token");

        return Result<string>.Success(tokenValue);
    }
}