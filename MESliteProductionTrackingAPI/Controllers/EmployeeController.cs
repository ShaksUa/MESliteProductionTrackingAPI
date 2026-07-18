using Application.DTO;
using Microsoft.AspNetCore.Mvc;

namespace MESliteProductionTrackingAPI.Controllers
{

    [ApiController]

    [Route("api/[controller]")]
    public class EmployeeController :ControllerBase
    {

        [HttpPost("AddEmployee")]
        public IActionResult Add(CreateEmployeeRequest createEmployeeRequest)
        {
            return Created();
        }

        [HttpGet("GetById{id}")]
        public IActionResult GetById(int id)
        {
            if (id > 0 && id < 50) return Ok("employee with id: " + id + " exists");
            if (id > 50) return NotFound(id + " is out of range");
            if (id == 50) return NoContent();
            return BadRequest(id + " id is not valid");
        }
    }
}
