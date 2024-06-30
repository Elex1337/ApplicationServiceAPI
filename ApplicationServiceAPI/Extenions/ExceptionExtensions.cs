using System.Net;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationServiceAPI.Extenions;

public static class ExceptionExtensions
{
    public static ProblemDetails GetProblemFromExtension(this Exception ex, HttpStatusCode status, HttpContext context, string title)
    {
        context.Response.StatusCode = (int)status;
        context.Response.ContentType = "application/problem+json";

        var problem = new ProblemDetails()
        {
            Title = title,
            Detail = ex.Message,
            Status = (int)status
        };

        if (ex is ValidationException validationException)
        {
            problem.Extensions.Add("errors", validationException.Errors
                .Select(x => new {Property = x.PropertyName, ErrorMessage = x.ErrorMessage}));
        }
        
        return problem;
    }
}