using Microsoft.AspNetCore.Mvc;
using ApplicationService.Application.Applications.Commands;
using MediatR;
using ApplicationServiceAPI.Contracts.Requests;
using ILogger = Serilog.ILogger;

namespace ApplicationServiceAPI.Controllers
{
    [ApiController]
    [Route("login")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator, ILogger<AuthController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Login) || string.IsNullOrEmpty(request.Password))
            {
                _logger.LogError("Empty Login ");
                return BadRequest("Missing login or password");
            }

            var result = await _mediator.Send(new LoginCommand(request.Login, request.Password));

            if (result.IsSuccess)
            {
                return Ok(new { Token = result.Value });
            }
            else
            {
                _logger.LogError("Unauthroized");
                return Unauthorized(result.Error.Message);
            }
        }
    }
}