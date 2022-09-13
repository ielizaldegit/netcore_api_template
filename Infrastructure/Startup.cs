using AspNetCoreRateLimit;
using Infrastructure.Auth;
using Infrastructure.Common;
using Infrastructure.Cors;
using Infrastructure.Mapping;
using Infrastructure.Middleware;
using Infrastructure.OpenApi;
using Infrastructure.Persistence;
using Infrastructure.RateLimit;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;


public static class Startup{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        MapsterSettings.Configure();

        return services
            //.AddApiVersioning()
            .AddAuth(config)
            //.AddBackgroundJobs(config)
            //.AddCaching(config)
            .AddRateLimit(config)
            .AddCorsPolicy(config)
            .AddExceptionMiddleware()
            //.AddHealthCheck()
            //.AddLocalization(config)
            //.AddMailing(config)
            //.AddMediatR(Assembly.GetExecutingAssembly())
            //.AddMultitenancy(config)
            //.AddNotifications(config)
            .AddOpenApiDocumentation(config)
            .AddPersistence(config)
            //.AddRequestLogging(config)
            //.AddRouting(options => options.LowercaseUrls = true)
            .AddServices();
    }


    //private static IServiceCollection AddApiVersioning(this IServiceCollection services) =>
    //services.AddApiVersioning(config =>
    //{
    //    config.DefaultApiVersion = new ApiVersion(1, 0);
    //    config.AssumeDefaultVersionWhenUnspecified = true;
    //    config.ReportApiVersions = true;
    //});

    //private static IServiceCollection AddHealthCheck(this IServiceCollection services) =>
    //    services.AddHealthChecks().AddCheck<TenantHealthCheck>("Tenant").Services;

    public static async Task InitializeDatabasesAsync(this IServiceProvider services, CancellationToken cancellationToken = default)
    {
        using var scope = services.CreateScope();
        await scope.ServiceProvider.GetRequiredService<ApplicationDbInitializer>().InitializeAsync(cancellationToken);
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder builder, IConfiguration config) =>
        builder
            //.UseLocalization(config)
            .UseIpRateLimiting()
            .UseHttpsRedirection()
            .UseStaticFiles()
            //.UseSecurityHeaders(config)
            //.UseFileStorage()
            .UseExceptionMiddleware()
            
            //.UseRouting()
            .UseCorsPolicy()
            .UseAuthentication()
        
            .UseCurrentUser()
            //.UseMultiTenancy()
            .UseAuthorization()
            //.UseRequestLogging(config)
            //.UseHangfireDashboard(config)
            
            .UseOpenApiDocumentation(config);

    //public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder builder)
    //{
    //    builder.MapControllers().RequireAuthorization();
    //    builder.MapHealthCheck();
    //    builder.MapNotifications();
    //    return builder;
    //}

    //private static IEndpointConventionBuilder MapHealthCheck(this IEndpointRouteBuilder endpoints) =>
    //    endpoints.MapHealthChecks("/api/health").RequireAuthorization();


}


