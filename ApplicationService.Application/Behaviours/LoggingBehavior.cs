using System.Text.Json;
using System.Text.Json.Nodes;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ApplicationService.Application.Behaviours;

public class LoggingBehavior<TRequest, TResponse>(
    ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var correlationId = Guid.NewGuid();
        
        logger.LogInformation("Handling request {RequestName}, {correlationId}", request.GetType().Name, correlationId);
        
        var response = await next();
        
        logger.LogInformation("Finished handling request {RequestName}, {correlationId}", request.GetType().Name, correlationId);
            
        return response;
    }
    
    
}