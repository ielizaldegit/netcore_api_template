﻿using AspNetCoreRateLimit;
using Core.Application.Auth;
using Infrastructure.Auth;
using Infrastructure.Common;
using Infrastructure.Cors;
using Infrastructure.Localization;
using Infrastructure.Middleware;
using Infrastructure.OpenApi;
using Infrastructure.Persistence;
using Infrastructure.RateLimit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;


public static class Startup{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        return services
            //.AddApiVersioning()
            .AddAutoMapper(typeof(AuthMapping).Assembly)
            .AddAuth(config)
            //.AddBackgroundJobs(config)
            //.AddCaching(config)
            .AddRateLimit(config)
            .AddCorsPolicy(config)
            .AddExceptionMiddleware()
            //.AddHealthCheck()
            .AddLocalization(config)
            //.AddMailing(config)
            //.AddMediatR(Assembly.GetExecutingAssembly())
            //.AddMultitenancy(config)
            //.AddNotifications(config)
            .AddOpenApiDocumentation(config)
            .AddPersistence(config)
            //.AddRequestLogging(config)
            .AddRouting(options => options.LowercaseUrls = true)
            
            .AddServices();
    }


    private static IServiceCollection AddApiVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(config =>
        {
            config.DefaultApiVersion = new ApiVersion(1, 0);
            config.AssumeDefaultVersionWhenUnspecified = true;
            config.ReportApiVersions = true;
            config.ApiVersionReader = new UrlSegmentApiVersionReader();
        });

        services.AddVersionedApiExplorer(o => { o.GroupNameFormat = "VVV"; o.SubstituteApiVersionInUrl = true; });

        return services;
    }



    //private static IServiceCollection AddHealthCheck(this IServiceCollection services) =>
    //    services.AddHealthChecks().AddCheck<TenantHealthCheck>("Tenant").Services;

    public static async Task InitializeDatabasesAsync(this IServiceProvider services, CancellationToken cancellationToken = default)
    {
        using var scope = services.CreateScope();
        await scope.ServiceProvider.GetRequiredService<ApplicationDbInitializer>().InitializeAsync(cancellationToken);
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder builder, IConfiguration config) =>
        builder
            .UseLocalization(config)
            .UseIpRateLimiting()
            .UseHttpsRedirection()
            .UseStaticFiles()
            //.UseSecurityHeaders(config)
            //.UseFileStorage()
            .UseExceptionMiddleware()
            
            .UseRouting()
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


