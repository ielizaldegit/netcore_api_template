using System;
using System.Security.Claims;

namespace Infrastructure.Auth;

    public interface ICurrentUserInitializer
    {
        void SetCurrentUser(ClaimsPrincipal user, string ip, string agent);

        void SetCurrentUserId(int userId);
    }


