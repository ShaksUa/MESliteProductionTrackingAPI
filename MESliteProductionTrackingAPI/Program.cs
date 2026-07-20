using System;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Application.Services;
using Microsoft.OpenApi;

namespace MESliteProductionTrackingAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            
            builder.Services.AddScoped<ITimeService, TimeService>();
            builder.Services.AddSingleton<IMessageService, MessageService>();
            //builder.Services.AddScoped<CustomMiddlwareService>();
            builder.Services.AddSingleton<EmployeeService>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });

            builder.Services.AddCors(options => {
                options.AddDefaultPolicy(policy => {
                    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            var app = builder.Build();

            app.UseCors();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.MapSwagger().RequireAuthorization();
            app.UseAuthorization();
            app.UseMiddleware<CustomMiddlwareService>();
            app.MapControllers();

            app.Run();
        }
    }
}
