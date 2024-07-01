using System.Security.Claims;
using ApplicationService.Application.Applications.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace ApplicationServiceAPI.Controllers
{
    [Route("myrequest")]
    [ApiController]
    [Authorize]
    public class RequestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetMyRequests()
        {   
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int userId))
            {
                return Unauthorized("User ID is not found or invalid in token");
            }

            var requests = await _mediator.Send(new ApplicationServiceMyRequestQuery(userId));
            return Ok(requests);
        }

    }
}