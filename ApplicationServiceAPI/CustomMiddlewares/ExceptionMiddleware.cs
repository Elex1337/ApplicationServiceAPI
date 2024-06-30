using System.Net;
using ApplicationServiceAPI.Extenions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationServiceAPI.CustomMiddlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;   

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)  
        {
            var problem =
                ex.GetProblemFromExtension(HttpStatusCode.BadRequest, context, "Validation failure");
            
            _logger.LogError(ex, "Validation failure"); 
            
            await context.Response.WriteAsJsonAsync(problem);
        }
        catch (Exception ex)
        {
            var problem =
                ex.GetProblemFromExtension(HttpStatusCode.InternalServerError, context, "Unhandled exception");
            
            _logger.LogError(ex, "Unhandled exception"); 
            await context.Response.WriteAsJsonAsync(problem);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/problem+json";
        var response = context.Response;
        var problem = new ProblemDetails();
        problem.Detail = exception.Message;
        switch (exception)
        {
            case ValidationException ex:
                problem.Title = "Validation exception";
                //var errors = ex.ValidationResult;
                problem.Detail = $"Error: {ex.Message}";
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                break;
            default:
                problem.Title = "Unhandled exception";
                problem.Status = (int)HttpStatusCode.InternalServerError;
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                break;
        }
        _logger.LogError(exception, "Unhandled exception"); 
        await context.Response.WriteAsJsonAsync(problem);
    }
    
}