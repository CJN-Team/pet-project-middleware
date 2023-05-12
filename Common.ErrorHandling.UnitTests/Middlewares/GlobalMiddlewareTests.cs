using Common.ErrorHandling.Middleware.Middlewares;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NSubstitute;
using System.Net;
using System.Text.Json;

namespace Common.ErrorHandling.Middleware.UnitTests.Middlewares;

public class GlobalMiddlewareTests
{
    private readonly IOptions<ApiBehaviorOptions> _options;

    public GlobalMiddlewareTests()
    {
        _options = Substitute.For<IOptions<ApiBehaviorOptions>>();
        _options.Value.Returns(new ApiBehaviorOptions()
        {
            ClientErrorMapping =
                {
                    [500] = new ClientErrorData()
                    {
                        Link = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                        Title = "An error occurred while processing your request."
                    }
            }
        });
    }

    [Fact]
    public async Task InvokeAsync_ShouldSetStatusCodeAndReturnProblemDetails_WhenExceptionThrown()
    {
        // Arrange
        var middleware = new GlobalMiddleware(_options);
        var context = new DefaultHttpContext();
        var next = new RequestDelegate(context => throw new Exception("Test exception"));
        context.Response.Body = new MemoryStream();

        // Act
        await middleware.InvokeAsync(context, next);

        // Assert
        context.Response.StatusCode.Should().Be((int)HttpStatusCode.InternalServerError);

        context.Response.ContentType.Should().Be("application/problem+json");
        context.Response.Body.Seek(0, SeekOrigin.Begin);

        var text = await new StreamReader(context.Response.Body).ReadToEndAsync();
        var problemDetails = JsonSerializer.Deserialize<ProblemDetails>(text);
        problemDetails.Should().NotBeNull();
        problemDetails?.Status.Should().Be((int)HttpStatusCode.InternalServerError);
        problemDetails?.Detail.Should().Be("Test exception");
    }
}