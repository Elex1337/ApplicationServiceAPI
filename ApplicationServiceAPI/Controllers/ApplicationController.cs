using ApplicationService.Application.Applications.Commands;
using ApplicationService.Application.Applications.Queries;
using ApplicationServiceAPI.Contracts.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationServiceAPI.Controllers;

[ApiController]
[Route("Заявки")]
public class ApplicationController : ControllerBase
{
    private readonly IMediator _mediator;

    public ApplicationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("Мои заявки")]
    public async Task<ActionResult> GetMyRequests(int userId)
    {
        var requests = await _mediator.Send(new ApplicationServiceMyRequestQuery(userId));
        return Ok(requests);

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
            return BadRequest();
        }
    }
}