namespace BeerlandWeb.Core.Extensions;

public static class HttpRequestExtension
{
    public static bool IsAjaxRequest(this HttpRequest request) => request.Headers.XRequestedWith == "XMLHttpRequest";
}