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

        [HttpPost]
        public IActionResult Add(CreateEmployeeRequest request)
        {
            var result = _employeeService.Create(request);
            if (result != null) return Created();
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _employeeService.GetById(id);
            if (result != null) return Ok(result);
            return NotFound();

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _employeeService.GetAll();
             return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var result = _employeeService.DeleteById(id);
            if (result) return NoContent();
            return NotFound();
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateById(int id, UpdateEmployeeRequest updateEmployeeRequest)
        {
            var result = _employeeService.UpdateById(id,updateEmployeeRequest);
            if (result != null) return Ok(result);
            return NotFound();
        }
    }
}
