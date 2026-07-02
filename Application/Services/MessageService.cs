using Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class MessageService : IMessageService
    {
        private readonly ILogger<MessageService> _logger;
        public string Id;
        public MessageService(ILogger<MessageService> logger)
        {
            _logger = logger;
            Id = Guid.NewGuid().ToString();
        }
        public async Task<string> GetMessageAsync()
        {
            
            _logger.LogInformation(Id);
            _logger.LogInformation("Service before");

            await Task.Delay(2000);

            _logger.LogInformation("Service after");

            return "Hello from async service";
        }
    }
}
