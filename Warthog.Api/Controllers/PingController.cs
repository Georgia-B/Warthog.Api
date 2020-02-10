using Microsoft.AspNetCore.Mvc;

namespace Warthog.Api.Controllers
{
    public class PingController : ControllerBase
    {
        [ProducesResponseType(200)]
        [HttpGet]
        [Route("ping")]
        public string Ping()
        {
            return "OK";
        }
    }
}
