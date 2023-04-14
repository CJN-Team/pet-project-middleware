using Microsoft.AspNetCore.Builder;
using Pet.Project.Middleware.Middlewares;

namespace Pet.Project.Middleware.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseGlobalMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<GlobalMiddleware>();
    }
}
