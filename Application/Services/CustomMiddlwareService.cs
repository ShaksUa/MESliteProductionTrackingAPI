using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System; 
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Application.Services
{
    public class CustomMiddlwareService
    {
        private readonly ILogger<CustomMiddlwareService> _logger;
        private readonly RequestDelegate _next;

        public CustomMiddlwareService(ILogger<CustomMiddlwareService> logger, RequestDelegate requestDelegate)
        {
            _logger = logger;
            _next = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var startTime = DateTime.UtcNow;
            var Id = Guid.NewGuid();
            _logger.LogInformation("Request Path: " + context.Request.Path.ToString());
            _logger.LogInformation("RemoteIpAddress: " +context.Connection.RemoteIpAddress.ToString());
            _logger.LogInformation("User-Agent: " + context.Request.Headers["User-Agent"].ToString());
            
            await _next(context);
           
            var endTime = DateTime.UtcNow;

            var duration = endTime - startTime;
        }
            
    }
}
