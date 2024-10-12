using JiraClone.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using JiraClone.API.StartupExtensions;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<JiraCloneDbContext>(o =>
            o.UseNpgsql(builder.Configuration.GetConnectionString("Npgsql")));

builder = builder
    .ConfigureMediatorServices()
    .ConfigureFluentValidationServices()
    .ConfigureSwaggerServices()
    .ConfigureRedisCacheService()
    .ConfigureAuthenticationServices();

builder.Services.AddControllers();

/************App Build************/
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        //c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        //c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();

