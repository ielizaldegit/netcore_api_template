namespace Infrastructure.Auth;

public class SecuritySettings
{
    public string Provider { get; set; }
    public bool RequireConfirmedAccount { get; set; }
}

public class JwtSettings
{
    public string Key { get; set; }
    public int TokenExpirationInMinutes { get; set; }
    public int RefreshTokenExpirationInDays { get; set; }
}

