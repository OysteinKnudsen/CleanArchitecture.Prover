using System.Net;
using System.Net.Mime;
using System.Text.Json;
using CleanArchitecture.Prover.Web.Models;

namespace CleanArchitecture.Prover.Web.Middlewares;

internal sealed class GlobalExceptionHandlerMiddleware(ILogger<GlobalExceptionHandlerMiddleware> logger) : IMiddleware
{
    private readonly JsonSerializerOptions _jsonSerializerOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
 
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unhandled exception in CleanArchitecture.Prover {Message}", ex.Message);
            await HandleExceptionAsync(context, ex);
        }
    }
    
    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = MediaTypeNames.Application.Json;
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var response = new ErrorResponseViewModel(context.Response.StatusCode, $"Unhandled exception. {exception.Message}");
        var jsonResponse = JsonSerializer.Serialize(response, _jsonSerializerOptions);
        await context.Response.WriteAsync(jsonResponse);
    }
}