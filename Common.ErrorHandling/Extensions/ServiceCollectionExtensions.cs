using Microsoft.Extensions.DependencyInjection;
using Common.ErrorHandling.Middleware.Middlewares;

namespace Common.ErrorHandling.Middleware.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddGlobalMiddleware(this IServiceCollection services) 
    {
        return services.AddScoped<GlobalMiddleware>();
    }
}
