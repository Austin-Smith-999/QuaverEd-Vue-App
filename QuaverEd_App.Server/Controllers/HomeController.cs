using Microsoft.AspNetCore.Mvc;

namespace QuaverEd_App.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet(Name = "WelcomeHome")]
        public string Get()
        {
            return "Welcome Home";
        }
    }
}
