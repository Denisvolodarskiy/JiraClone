using JiraClone.Application.Extensions;
using JiraClone.Application.Features.Projects.Commands.CreateProject;
using JiraClone.Application.Features.Projects.Commands.DeleteProject;
using JiraClone.Application.Features.Projects.Commands.UpdateProject;
using JiraClone.Application.Features.Projects.Queries.GetAllProjects;
using JiraClone.Application.Features.Projects.Queries.GetProjectById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JiraClone.API.Controllers;


//[Authorize(Roles = "Admin")]
[ApiController]
[Route("api/[controller]")]
public class ProjectsController(IMediator mediator) : ControllerBase
{
   
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPost("create")]
    public async Task<ActionResult> CreateProject([FromBody] CreateProjectCommand command)
    {
        var result = await mediator.Send(command);
        return result.IsSuccess ? Ok(result.Value) : result.HandleErrors(this);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [HttpGet("getAll")]
    public async Task<IActionResult> GetAllProjects()
    {
        var result = await mediator.Send(new GetAllProjectsQuery());
        return result.IsSuccess ? Ok(result.Value) : result.HandleErrors(this);
    }


    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [HttpGet("getBy{id}")]
    public async Task<IActionResult> GetProjectById(int id)
    {
        var result = await mediator.Send(new GetProjectByIdQuery { ProjectId = id });
        return result.IsSuccess ? Ok(result.Value) : result.HandleErrors(this);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [HttpPut("update")]
    public async Task<IActionResult> UpdateProject([FromBody] UpdateProjectCommand command)
    {
        var result = await mediator.Send(command);
        return result.IsSuccess ? Ok(result.Value) : result.HandleErrors(this);
    }


    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteProject(int id)
    {
        var result = await mediator.Send(new DeleteProjectCommand { ProjectId = id });
        return result.IsSuccess ? Ok(result.Value) : result.HandleErrors(this);
    }
}