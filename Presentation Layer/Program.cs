using Application;
using Infrastructure.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Presentation_Layer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Add Controllers
            builder.Services.AddControllers();

            // Add Swagger/OpenAPI for API documentation
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Library API",
                    Version = "v1",
                    Description = "An API for managing books and authors in a library."
                });
            });

            // Add Application and Infrastructure services
            builder.Services.AddApplicationServices(); // Extension method for Application Layer services
            builder.Services.AddInfrastructureServices(); // Extension method for Infrastructure Layer services

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Library API v1");
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
