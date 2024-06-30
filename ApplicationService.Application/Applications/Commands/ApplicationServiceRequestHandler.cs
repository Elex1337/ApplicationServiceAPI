using ApplicationService.Application.Interfaces;
using ApplicationService.Domain.Entities;
using KDS.Primitives.FluentResult;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ApplicationService.Application.Applications.Commands;

public class ApplicationServiceRequestHandler : IRequestHandler<ApplicationServiceRequestCommand, Result<Request>>
{
    private readonly IRepository _repository;
    private readonly ILogger<ApplicationRegisterUserCommandHandler> _logger;

    public ApplicationServiceRequestHandler(IRepository repository, ILogger<ApplicationRegisterUserCommandHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }
    
    public  async Task<Result<Request>> Handle(ApplicationServiceRequestCommand request, CancellationToken cancellationToken)
    {
      _logger.LogInformation("Start command");

      var eRequest = new Request
      {
        PhoneNumber = request.PhoneNumber,
        FullName = request.FullName,
        Email = request.Email,
        RequestTypeId = request.RequestTypeId,
        UserId = request.UserId,
        CreatedAt = DateTime.UtcNow,
      };
      await _repository.AddRequestAsync(eRequest, cancellationToken);
      await _repository.SaveChangesAsync(cancellationToken);
      
      _logger.LogInformation("End command");
      
      return Result.Success(eRequest);

    }
}