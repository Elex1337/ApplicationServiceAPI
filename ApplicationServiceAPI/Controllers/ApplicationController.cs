using ApplicationService.Application.Applications.Commands;
using ApplicationService.Application.Applications.Queries;
using ApplicationServiceAPI.Contracts.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace ApplicationServiceAPI.Controllers;

[ApiController]
[Route("applications")]
public class ApplicationController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<ApplicationController> _logger;

    public ApplicationController(IMediator mediator, ILogger<ApplicationController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }
    
    [HttpPost]
    public async Task<ActionResult> PostApplication([FromBody] ApplictaionRequest request)
    {
        var newrequest = await _mediator.Send(
            new ApplicationServiceRequestCommand(
                request.PhoneNumber,
                request.FullName,
                request.Email,
                request.RequestTypeId,
                request.UserId));
        if (newrequest.IsSuccess)
        {
            return Ok(newrequest);
        }

        {
            _logger.LogError("пройзошла ошибка в заявке");
            return BadRequest();
        }
    }
}