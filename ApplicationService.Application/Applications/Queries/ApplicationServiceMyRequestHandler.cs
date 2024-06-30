using ApplicationService.Application.Interfaces;
using ApplicationService.Domain.Entities;
using KDS.Primitives.FluentResult;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApplicationService.Application.Applications.Queries;

public class ApplicationServiceMyRequestHandler :  IRequestHandler<ApplicationServiceMyRequestQuery, Result<List<Request>>>
{
    private readonly IRepository _repository;
    private readonly ILogger<ApplicationServiceMyRequestHandler> _logger;

    public ApplicationServiceMyRequestHandler(IRepository repository, ILogger<ApplicationServiceMyRequestHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<Result<List<Request>>> Handle(ApplicationServiceMyRequestQuery request, CancellationToken cancellationToken)
    {
     _logger.LogInformation("Start query");

     var myrequests = await _repository.GetMyRequests()
         .Where(x => x.UserId == request.UserId)
         .ToListAsync(cancellationToken);
     _logger.LogInformation("end query");

     return Result.Success(myrequests);
    }
}