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
        private readonly ILogger<RequestController> _logger;
        private readonly IMediator _mediator;

        public RequestController(IMediator mediator, ILogger<RequestController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetMyRequests()
        {   
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int userId))
            {
                _logger.LogError("Юзер не найден");
                return Unauthorized("Юзер не найден или не правильный токен");
            }

            var requests = await _mediator.Send(new ApplicationServiceMyRequestQuery(userId));
            return Ok(requests);
        }

    }
}