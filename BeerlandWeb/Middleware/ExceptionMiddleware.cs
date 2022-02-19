using System.Net;
using System.Text.Json;
using BeerlandWeb.Core.Extensions;
using DAL.Entities;

namespace BeerlandWeb.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            await HandleExceptionAsync(httpContext, ex);
        }
    }
    
    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        if (context.Request.IsAjaxRequest())
        {
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(new ErrorModel()
            {
                ErrorMessage = exception.Message,
            }));
        }
        else
        {
            context.Response.Redirect("/Error/error");
        }
    }
}