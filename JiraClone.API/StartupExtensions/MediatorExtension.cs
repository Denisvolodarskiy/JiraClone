using JiraClone.Application.Features.Projects.Commands.CreateProject;
using JiraClone.Application.Features.Projects.Queries.GetProjectById;
using JiraClone.Application.Features.Tasks.Queries.GetTaskById;
using JiraClone.Application.Features.Users.Commands;
using JiraClone.Application.Features.Users.Commands.CreateUser;

namespace JiraClone.API.StartupExtensions;

public static class MediatorExtension
{

    public static WebApplicationBuilder ConfigureMediatorServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateProjectCommand).Assembly));
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetProjectByIdQuery).Assembly));
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateUserCommand).Assembly));
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetTaskByIdQuery).Assembly));
        //builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateTaskCommand).Assembly));
        return builder;
    }
}
