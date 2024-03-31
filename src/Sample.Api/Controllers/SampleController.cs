using Microsoft.AspNetCore.Mvc;

namespace Sample.Api.Controllers
{
    [ApiController]
    [Route("sample")]
    public class SampleController : ControllerBase
    {
        public string Today() => DateTime.Now.ToString("dd/MM/yyyy");
    }
}
