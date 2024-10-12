using JiraClone.Application.Extensions;
using JiraClone.Application.Features.Tasks.Commands.AssignTask;
using JiraClone.Application.Features.Tasks.Commands.CreateTask;
using JiraClone.Application.Features.Tasks.Commands.DeleteTask;
using JiraClone.Application.Features.Tasks.Commands.UpdateTask;
using JiraClone.Application.Features.Tasks.Queries.GetTaskById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JiraClone.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController(IMediator mediator) : ControllerBase
{
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateTask([FromBody] CreateTaskCommand command)
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
    [HttpGet("getBy{id}")]
    public async Task<IActionResult> GetTaskById(int id)
    {
        var result = await mediator.Send(new GetTaskByIdQuery { TaskId = id });
        return result.IsSuccess ? Ok(result.Value) : result.HandleErrors(this);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [HttpPut("updateById")]
    public async Task<IActionResult> UpdateTask( [FromBody] UpdateTaskCommand command)
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
    [HttpPost("assignUserById")]
    public async Task<IActionResult> AssignTaskToUser([FromBody] AssignTaskCommand command)
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
    [HttpDelete("deleteById")]
    public async Task<IActionResult> DeleteTask([FromBody] DeleteTaskCommand command)
    {
        var result = await mediator.Send(command);
        return result.IsSuccess ? Ok(result.Value) : result.HandleErrors(this);
    }
}
