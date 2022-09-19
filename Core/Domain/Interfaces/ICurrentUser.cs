using System.Security.Claims;

namespace Core.Interfaces;

public interface ICurrentUser
{
    string Name { get; }
    int GetUserId();
    string GetUserEmail();
    string GetUserIp();
    string GetUserAgent();
    bool IsAuthenticated();
    bool IsInRole(string role);
    IEnumerable<Claim> GetUserClaims();
}


