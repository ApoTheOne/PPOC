using CorePOC.Middlewares;
using Microsoft.AspNetCore.Builder;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseRouteHandlerMiddleware(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RouteHandler>();
    }

    public static IApplicationBuilder UseLoginMiddleware(
            this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<LoginMiddleware>();
    }

    public static IApplicationBuilder UseRegistrationMiddleware(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RegistrationMiddleware>();
    }
}