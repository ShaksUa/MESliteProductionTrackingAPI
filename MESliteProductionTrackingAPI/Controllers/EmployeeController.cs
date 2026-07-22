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
            var result = _employeeService.GetById(id);
            if (result != null) return Ok(result);
            return NotFound();

        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _employeeService.GetAll();
            if (result != null) return Ok(result);
            return NotFound();
        }

        [HttpDelete("DeleteById/{id}")]
        public IActionResult DeleteById(int id)
        {
            var result = _employeeService.DeleteById(id);
            if (result) return Ok("deleted: " + id);
            return NotFound();
        }

        [HttpPatch("UpdateById/{id}")]
        public IActionResult UpdateById(int id, UpdateEmployeeRequest updateEmployeeRequest)
        {
            var result = _employeeService.UpdateById(id,updateEmployeeRequest);
            if (result) return Ok("updated: " + id);
            return NotFound();
        }
    }
}
