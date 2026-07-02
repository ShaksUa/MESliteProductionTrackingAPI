using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MESliteProductionTrackingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly ILogger<MessageController> _logger;
        private readonly IMessageService _messageService;
        private readonly IServiceProvider _serviceProvider;

        public MessageController(ILogger<MessageController> logger, IMessageService messageService, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _messageService = messageService;
            _serviceProvider = serviceProvider;
        }

        [HttpGet]
        
        public async Task<IActionResult> GetMessage()
        {
            //_logger.LogInformation("Controller Before (constructor service)");

            var result1 = await _messageService.GetMessageAsync();

           // _logger.LogInformation("After first call (constructor service)");

            var serviceFromProvider = _serviceProvider.GetRequiredService<IMessageService>();
            var result2 = await serviceFromProvider.GetMessageAsync();

            //_logger.LogInformation("Controller After (provider service)");

            return Ok(new
            {
                FirstCall = result1,
                SecondCall = result2
            });
        }
    }
}
