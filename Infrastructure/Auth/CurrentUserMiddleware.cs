using Microsoft.AspNetCore.Http;

namespace Infrastructure.Auth;

public class CurrentUserMiddleware : IMiddleware
{
    private readonly ICurrentUserInitializer _currentUserInitializer;

    public CurrentUserMiddleware(ICurrentUserInitializer currentUserInitializer) =>
        _currentUserInitializer = currentUserInitializer;

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var ip = context.Connection.RemoteIpAddress?.MapToIPv4().ToString() ?? "N/A";
        var agent = context.Request.Headers["User-Agent"];
        _currentUserInitializer.SetCurrentUser(context.User, ip, agent);

        await next(context);
    }
}