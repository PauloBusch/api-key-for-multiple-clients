using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Sample.Api.Controllers;

[ApiController]
[Route("sample")]
public class SampleController : ControllerBase
{
    [HttpGet("today")]
    public string Today() => DateTime.Now.ToString("dd/MM/yyyy");

    [Authorize]
    [HttpGet("details")]
    public dynamic IsAuthenticated()
    {
        var identity = HttpContext.User.Identity;
        return new
        {
            ClientId = identity?.Name,
            identity?.IsAuthenticated,
            identity?.AuthenticationType
        };
    }
}
