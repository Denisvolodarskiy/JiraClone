using JiraClone.Domain.Common;
using JiraClone.Domain.Entities.ApplicationUser;

namespace JiraClone.Infrastructure.Helpers
{
    public interface IJwtHelper
    {
        Result<string> GenerateToken(User user);
    }
}