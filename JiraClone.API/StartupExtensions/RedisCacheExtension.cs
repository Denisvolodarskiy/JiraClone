using JiraClone.Infrastructure.Helpers;

namespace JiraClone.API.StartupExtensions;

public static class RedisCacheExtension
{
    public static WebApplicationBuilder ConfigureRedisCacheService(this WebApplicationBuilder builder)
    {

        builder.Services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = builder.Configuration.GetConnectionString("Redis");
        });

        builder.Services.AddSingleton<ICacheHelper, CacheHelper>();

        return builder;
    }
}
