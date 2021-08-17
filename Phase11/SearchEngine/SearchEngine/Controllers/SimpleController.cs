using Microsoft.AspNetCore.Mvc;

namespace SearchEngine.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class SimpleController : ControllerBase
    {
        [HttpGet]
        [Route("Get")]
        public string Get()
        {
            return "Hey There!";
        }
    }
}