using Microsoft.AspNetCore.Builder;
using Common.ErrorHandling.Middleware.Middlewares;

namespace Common.ErrorHandling.Middleware.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseGlobalMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<GlobalMiddleware>();
    }
}
