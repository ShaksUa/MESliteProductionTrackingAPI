using Microsoft.AspNetCore.Mvc;

namespace MESliteProductionTrackingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet ("hello")]
        public IActionResult Hello()
        {
            return Ok("Hello");
        }

        [HttpGet ("add")]
        public IActionResult Add(int a, int b)
        {
            return Ok (a + b);
        }
    }
}
