using ApplicationService.Application.Applications.Commands;
using ApplicationServiceAPI.Contracts.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationServiceAPI.Controllers
{
    [ApiController]
    [Route("registration")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
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
                return BadRequest();
            }
        }
    }
}