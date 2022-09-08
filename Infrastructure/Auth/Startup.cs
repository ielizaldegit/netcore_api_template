using System.Security.Claims;
using System.Text;
using Core.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Auth;

internal static class Startup
{

    internal static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<CurrentUserMiddleware>()
                .AddScoped<ICurrentUser, CurrentUser>()
                .AddScoped(sp => (ICurrentUserInitializer)sp.GetRequiredService<ICurrentUser>());


        services.Configure<SecuritySettings>(config.GetSection(nameof(SecuritySettings)));
        services.Configure<JwtSettings>(config.GetSection($"SecuritySettings:{nameof(JwtSettings)}"));
        var jwtSettings = config.GetSection($"SecuritySettings:{nameof(JwtSettings)}").Get<JwtSettings>();


        if (string.IsNullOrEmpty(jwtSettings.Key)) throw new InvalidOperationException("No Key defined in JwtSettings config.");

        return services
            .AddAuthentication(authentication =>
            {
                authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(bearer =>
            {
                bearer.RequireHttpsMetadata = false;
                bearer.SaveToken = true;
                bearer.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Key)),
                    ValidateIssuer = false,
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    RoleClaimType = ClaimTypes.Role,
                    ClockSkew = TimeSpan.Zero
                };
                bearer.Events = new JwtBearerEvents
                {
                    OnChallenge = context =>
                    {
                        context.HandleResponse();
                        if (!context.Response.HasStarted)
                        {
                            //throw new UnauthorizedException("Authentication Failed.");
                            throw new Exception("Authentication Failed.");
                        }

                        return Task.CompletedTask;
                    },
                    OnForbidden = _ => throw new Exception("You are not authorized to access this resource."), //throw new ForbiddenException("You are not authorized to access this resource."),
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"];

                        if (!string.IsNullOrEmpty(accessToken) &&
                            context.HttpContext.Request.Path.StartsWithSegments("/notifications"))
                        {
                            // Read the token out of the query string
                            context.Token = accessToken;
                        }

                        return Task.CompletedTask;
                    }
                };
            })
            .Services;



    }

    internal static IApplicationBuilder UseCurrentUser(this IApplicationBuilder app) => app.UseMiddleware<CurrentUserMiddleware>();





}


