using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Game.Application.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddSwaggerExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Game - WebApi"
                });
            });
        }
    }
}
