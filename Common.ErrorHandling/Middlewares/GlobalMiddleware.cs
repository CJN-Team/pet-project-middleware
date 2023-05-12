using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Common.ErrorHandling.Middleware.Common;
using System.Net;
using System.Text.Json;

namespace Common.ErrorHandling.Middleware.Middlewares;

public class GlobalMiddleware : IMiddleware
{
    private readonly ApiBehaviorOptions _options;

    public GlobalMiddleware(IOptions<ApiBehaviorOptions> options)
    {
        _options = options?.Value!;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            if (ExceptionStatusCodeMap.exceptionStatusCodes.TryGetValue(e.GetType(), out int mappedStatusCode))
            {
                context.Response.StatusCode = mappedStatusCode;
            }

            var problemDetails = new ProblemDetails()
            {
                Status = context.Response.StatusCode,
                Detail = e.Message
            };

            if (_options.ClientErrorMapping.TryGetValue(context.Response.StatusCode, out var clientErrorData))
            {
                problemDetails.Title = clientErrorData.Title;
                problemDetails.Type = clientErrorData.Link;
            }

            string json = JsonSerializer.Serialize(problemDetails);
            context.Response.ContentType = "application/problem+json";

            await context.Response.WriteAsync(json);
        }
    }
}