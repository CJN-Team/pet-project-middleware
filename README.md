# Pet Project Middleware

Pet.Project.Middleware is a middleware library for ASP.NET Core that provides a global exception handling mechanism. This middleware intercepts all exceptions thrown by controllers or other middlewares in the pipeline and returns a JSON payload that conforms to the Problem Details for HTTP APIs specification. It also maps some exception types to their corresponding HTTP status codes.

## Installation

To use the middleware, first install the **Pet.Project.Middleware** package from NuGet:

```csharp
dotnet add package Pet.Project.Middleware
```

Add the following code to IServiceCollection in your Program.cs file to register using the extension methods of the middleware:

```csharp
builder.Services.AddGlobalMiddleware();
```

then add the following code to the IApplicationBuilder to use the middleware:

```csharp
app.UseGlobalMiddleware();
```

Note that the middleware is registered as scoped (AddScoped&lt;GlobalMiddleware>()) in the service container in the example above. This is recommended for middlewares that need access to scoped dependencies.

## Usage

Once the middleware is added to the pipeline, it will automatically handle any exceptions thrown by subsequent middleware components or controllers. If an exception occurs, the middleware will return a JSON payload that conforms to the Problem Details for HTTP APIs specification.

For example, if a System.ArgumentException is thrown, the middleware will return a response with a status code of 400 (Bad Request) and a JSON payload that looks like this:

```json
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "Bad Request",
  "detail": "Some detail about the error.",
  "status": 400
}
```

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License

This project is licensed under the [Creative Commons Attribution-NonCommercial-NoDerivatives 4.0 International](LICENSE.md) license.
