using Microsoft.Extensions.DependencyInjection;
using Pet.Project.Middleware.Middlewares;

namespace Pet.Project.Middleware.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddGlobalMiddleware(this IServiceCollection services) 
    {
        return services.AddScoped<GlobalMiddleware>();
    }
}
