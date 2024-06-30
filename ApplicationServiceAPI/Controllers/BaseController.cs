using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationServiceAPI.Controllers;

[ApiController]
public class BaseController : ControllerBase
{
    public ISender Sender => HttpContext.RequestServices.GetRequiredService<ISender>();
    
}