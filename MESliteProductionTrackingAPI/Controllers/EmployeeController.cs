using Application.DTO;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace MESliteProductionTrackingAPI.Controllers
{

    [ApiController]

    [Route("api/[controller]")]
    public class EmployeeController :ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController (EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost("AddEmployee")]
        public IActionResult Add(CreateEmployeeRequest request)
        {
            var result = _employeeService.Create(request);
            //return Ok(result);
            return Created("GetById/" + result.Id, result);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            if (id > 0 && id < 50) return Ok("employee with id: " + id + " exists");
            if (id > 50) return NotFound(id + " is out of range");
            if (id == 50) return NoContent();
            return BadRequest(id + " id is not valid");
        }
    }
}
