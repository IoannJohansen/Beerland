using System.Net;
using System.Text.Json;
using BeerlandWeb.Core.Extensions;
using DAL.Entities;
using NLog;
using LogLevel = NLog.LogLevel;

namespace BeerlandWeb.Core.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

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
            var errorModel = new ErrorModel
            {
                ErrorMessage = "Something went wrong!",
                ErrorId = Guid.NewGuid()
            };
            var logger = LogManager.GetCurrentClassLogger();
            var errorInfo = new LogEventInfo(LogLevel.Error, nameof(ExceptionMiddleware), ex.Message)
            {
                Properties =
                {
                    ["ErrorId"] = errorModel.ErrorId
                },
                Exception = ex
            };
            logger.Error(errorInfo);
            await HandleExceptionAsync(httpContext, errorModel);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, ErrorModel error)
    {
        context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
        if (context.Request.IsAjaxRequest())
        {
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(error));
        }
        else
        {
            context.Response.Redirect("/Error/error");
        }
    }
}