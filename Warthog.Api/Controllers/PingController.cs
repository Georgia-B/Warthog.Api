using Microsoft.AspNetCore.Mvc;

namespace Warthog.Api.Controllers
{
    public class PingController : Controller
    {
        [HttpGet("ping")]
        public string Get()
        {
            return "OK";
        }
    }
}
