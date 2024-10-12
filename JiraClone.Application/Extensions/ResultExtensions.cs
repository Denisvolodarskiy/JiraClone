using JiraClone.Domain.Common;
using JiraClone.Domain.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JiraClone.Application.Extensions;

public static class ResultExtensions
{
    public static ActionResult HandleErrors(this Result result, ControllerBase controller)
    {

        if (result.Error == ProjectErrors.ProjectWithTitleAlreadyExist)
        {

            return controller.Problem(
                statusCode: StatusCodes.Status400BadRequest,
                detail: result.Error.Message,
                title: result.Error.Code
                );
        }
        else
        {
            return controller.Problem(
                statusCode: StatusCodes.Status500InternalServerError,
                detail: result.Error.Message,
                title: result.Error.Code
                );
        }
        //var problemDetails = new ProblemDetails
        //{
        //    Status = (int)result.StatusCode,
        //    Title = "An error occurred while processing your request.",
        //    Detail = result.Error,
        //};

        //return new ObjectResult(problemDetails);
    }
}
