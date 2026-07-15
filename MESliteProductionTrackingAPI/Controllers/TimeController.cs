using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MESliteProductionTrackingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimeController: ControllerBase
    {
        private readonly ITimeService _timeService;

        public TimeController(ITimeService timeService)
        {
            _timeService = timeService;
        }

        [HttpGet]
        public IActionResult GetCurrentTime()
        {
            DateTime currentDateTime = _timeService.Now();
            var valueExists = HttpContext.Items.TryGetValue("Id", out var value);
            return Ok(new { Message = "Current time: ", Time = currentDateTime, ValueExistst = valueExists, Id = value});
        }
    }
}
