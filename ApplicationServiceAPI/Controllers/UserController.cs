using ApplicationService.Application.Applications.Commands;
using ApplicationServiceAPI.Contracts.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationServiceAPI.Controllers
{
    [ApiController]
    [Route("registration")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;

        public UserController(IMediator mediator,ILogger<UserController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpPost]
        public async Task<ActionResult> Register([FromBody] UserRequest request)
        {
            var newUser = await _mediator.Send(
                new ApplicationServiceRegistrationCommand(
                request.Login,
                request.FullName,
                request.Email,
                request.Password));
            
            if (newUser.IsSuccess)
            {
                return Ok(newUser);
            }
            {
                _logger.LogError("Что то случилось при регистарции");
                return BadRequest();
            }
        }
    }
}