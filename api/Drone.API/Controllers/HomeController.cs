using Microsoft.AspNetCore.Mvc;

namespace Drone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // GET: api/Home
        [HttpGet]
        public string Get()
        {
            return "Welcome to Drone Api!";
        }
    }
}
