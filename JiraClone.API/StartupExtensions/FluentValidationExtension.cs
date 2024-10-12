using FluentValidation.AspNetCore;
using FluentValidation;
using JiraClone.Application.Validators.Project;
using System.Reflection;
using JiraClone.Application.Validators.Task;
using JiraClone.Application.Validators.User;

namespace JiraClone.API.StartupExtensions;

public static class FluentValidationExtension
{
    public static WebApplicationBuilder ConfigureFluentValidationServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddFluentValidationAutoValidation();
        builder.Services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(CreateProjectCommandValidator)));
        builder.Services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(CreateTaskCommandValidator)));
        builder.Services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(CreateUserCommandValidator)));

        return builder;
    }
}
