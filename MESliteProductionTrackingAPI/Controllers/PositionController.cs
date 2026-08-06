using Application.DTO;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace MESliteProductionTrackingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PositionController : ControllerBase
    {
        private readonly PositionService _positionService;
        public PositionController(PositionService positionService)
        {
            _positionService = positionService;
        }

        [HttpPost]
        public IActionResult Create(CreatePositionRequests createPositionRequests)
        {
            var result = _positionService.Create(createPositionRequests);
            if (result != null) return Created();
            return NoContent();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _positionService.GetById(id);
            if (result != null) return Ok(result);
            return NotFound();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _positionService.GetAll();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _positionService.Delete(id);
            if (result) return NoContent();
            return NotFound();
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateById(int id, UpdatePositionRequest updatePositionRequest)
        {
            var result = _positionService.UpdateById(id, updatePositionRequest);
            if (result != null) return Ok(result);
            return NotFound();
        }


    }
}
