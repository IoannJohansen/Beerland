using System.Net;
using System.Text.Json;
using BeerlandWeb.Core.Extensions;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BeerlandWeb.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;
    
    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
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
            context.Response.Redirect("/Home/error");
        }
    }
}