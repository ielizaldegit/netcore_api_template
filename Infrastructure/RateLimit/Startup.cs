using AspNetCoreRateLimit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.RateLimit
{
    internal static class Startup
    {

        internal static IServiceCollection AddRateLimit(this IServiceCollection services, IConfiguration config)
        {
            services.AddMemoryCache();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddInMemoryRateLimiting();
            services.Configure<IpRateLimitOptions>(config.GetSection("IpRateLimiting"));

            return services;
        }


    }

}

