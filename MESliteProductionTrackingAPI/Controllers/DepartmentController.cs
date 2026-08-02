using Application.DTO;
using Application.Services;
using Domain.Entries;
using Microsoft.AspNetCore.Mvc;

namespace MESliteProductionTrackingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentService _departmentService;

        public DepartmentController(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpPost("Department")]
        public IActionResult Create(CreateDepartmentRequest createDepartmentRequest)
        {
            var result = _departmentService.Create(createDepartmentRequest);
            return Created();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _departmentService.GetById(id);
            if (result != null) return Ok(result);
            return NotFound();
        }

        [HttpPost("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _departmentService.DeleteById(id);
            if (result == true) return NotFound();
            else return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult Update(int id, UpdateDepartmentRequest updateDepartmentRequest)
        {
            var result = _departmentService.UpdateById(id, updateDepartmentRequest);
            if (result != null) return Ok(result);
            else return NotFound();

        }

        [HttpGet("GetAllDepartments")]
        public IActionResult GetAll()
        {
            var result = _departmentService.GetAll();
            return Ok(result);
        }
    }
}
