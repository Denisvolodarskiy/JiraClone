
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JiraClone.Infrastructure.Constants;

public static class Constants
{
    public static class Authentication
    {
        public const string UserId = "UserId";
    }
    public static class DataBase
    {
        public const string UserRoleTableName = "AspNetRoles";

        public const string UsersTableName = "AspNetUsers";
    }
}
