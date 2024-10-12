using Microsoft.OpenApi.Models;

namespace JiraClone.API.StartupExtensions;

public static class SwaggerExtension
{
    public static WebApplicationBuilder ConfigureSwaggerServices(this WebApplicationBuilder builder)
    {
        //builder.Services.AddSwaggerGen();


        //============ Swagger =============
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new() { Title = "JiraClone", Version = "v1" });

            //============ Jwt Settings =============
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please insert JWT with Bearer into field",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });
        });

        return builder;
    }
}
