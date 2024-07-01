using ApplicationService.Application.Applications.Commands;
using ApplicationService.Application.Applications.Queries;
using ApplicationServiceAPI.Contracts.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationServiceAPI.Controllers;

[ApiController]
[Route("applications")]
public class ApplicationController : ControllerBase
{
    private readonly IMediator _mediator;

    public ApplicationController(IMediator mediator)
    {
        _mediator = mediator;
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