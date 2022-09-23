﻿using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;

namespace Infrastructure.Localization;


internal static class Startup
{
    internal static IServiceCollection AddLocalization(this IServiceCollection services, IConfiguration config)
    {
        services.AddLocalization();
        services.AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();
        services.AddDistributedMemoryCache();
        services.AddSingleton<LocalizationMiddleware>();
        return services;
    }

    internal static IApplicationBuilder UseLocalization(this IApplicationBuilder app, IConfiguration config)
    {
        app.UseRequestLocalization(new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture(new CultureInfo("es-MX"))
        });
        app.UseMiddleware<LocalizationMiddleware>();

        return app;
    }
}

