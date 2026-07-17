using Application.Orders.DTO;
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

        [HttpGet("product/{id}")]
        public IActionResult GetProductById (string category, int page, int pagesize)
        {
            
            return Ok("category: " + category + " page: " + page + " pagesize: " + pagesize);
        }

        [HttpPost("product")]
        public IActionResult CreateProduct (CreateProductRequest createProductRequest)
        {
            return Ok(createProductRequest);
                //("id: " + id + " Name: " + name + " Description: " + descr + " Create Time:" +creatTime);
        }
    }
}
