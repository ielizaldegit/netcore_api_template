using System;
using System.Security.Claims;
using System.Security.Principal;
using Core.Interfaces;

namespace Infrastructure.Auth;

public class CurrentUser : ICurrentUser, ICurrentUserInitializer
{
    private ClaimsPrincipal _user;

    public string Name => _user?.Identity?.Name;
    private int _userId = 0;

    private string _ip = "";
    private string _agent = "";



    public int GetUserId() =>
    IsAuthenticated()
            ? int.Parse(FindFirstValue(_user, ClaimTypes.NameIdentifier) ?? null)
            : _userId;

    public string GetUserEmail() =>
        IsAuthenticated()
            ? FindFirstValue(_user, ClaimTypes.Email)
            : string.Empty;

    public string GetUserIp() => _ip;

    public string GetUserAgent() => _agent;


    public bool IsAuthenticated() => _user?.Identity?.IsAuthenticated is true;

    public bool IsInRole(string role) => _user?.IsInRole(role) is true;

    public IEnumerable<Claim> GetUserClaims() => _user?.Claims;


    public void SetCurrentUser(ClaimsPrincipal user, string ip, string agent)
    {
        if (_user != null)
        {
            throw new Exception("Method reserved for in-scope initialization");
        }
        _user = user;
        _ip = ip;
        _agent = agent;
    }

    public void SetCurrentUserId(int userId)
    {
        if (_userId < 0)
        {
            throw new Exception("Method reserved for in-scope initialization");
        }
        _userId = userId;
    }


    private static string FindFirstValue(ClaimsPrincipal principal, string claimType) =>
     principal is null
         ? throw new ArgumentNullException(nameof(principal))
         : principal.FindFirst(claimType)?.Value;


}
