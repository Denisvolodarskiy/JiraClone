using JiraClone.Application.Constants;
using JiraClone.Domain.Entities.ApplicationUser;
using JiraClone.Infrastructure.DbContexts;
using JiraClone.Infrastructure.Helpers;
using JiraClone.Infrastructure.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace JiraClone.API.StartupExtensions;

public static class AuthenticationExtension
{
    public static WebApplicationBuilder ConfigureAuthenticationServices(this WebApplicationBuilder builder)
    {

        //============Identity =============
        builder.Services.AddIdentity<User, UserRole>()
        .AddEntityFrameworkStores<JiraCloneDbContext>()
        .AddDefaultTokenProviders();

        //============ Authentication(JWT Bearer)
       
        builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtSettings"));
        var jwtOptions = builder.Configuration.GetSection("JwtSettings").Get<JwtOptions>();

        builder.Services.AddSingleton(jwtOptions);
        builder.Services.AddSingleton<IJwtHelper, JwtHelper>();

        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

        }).AddJwtBearer(x =>
        {
            if (jwtOptions != null)
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {

                    ValidIssuer = jwtOptions.Issuer,
                    ValidAudience = jwtOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey)),

                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            }
        });

        //============ Authorization=============
        builder.Services.AddAuthorization();


        //============ Roles =============
        InitializeRoles(builder.Services.BuildServiceProvider()).GetAwaiter();


        return builder;

    }

    private static async Task InitializeRoles(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<UserRole>>();

        foreach (var roleName in ApplicationConstants.Roles.RoleNames)
        {
            try
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    var roleResult = await roleManager.CreateAsync(new UserRole { Name = roleName });
                    if (!roleResult.Succeeded)
                    {
                        throw new Exception($"Error creating role {roleName}: {string.Join(", ", roleResult.Errors.Select(e => e.Description))}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception while creating role {roleName}: {ex.Message}");
            }
        }
    }

}