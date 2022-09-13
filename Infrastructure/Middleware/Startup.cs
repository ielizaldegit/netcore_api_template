using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Infrastructure.Middleware;

internal static class Startup
{
    internal static IServiceCollection AddExceptionMiddleware(this IServiceCollection services)
    {

        services.AddScoped<ExceptionMiddleware>();

        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = actionContext =>
            {
                string errorId = Guid.NewGuid().ToString();
                var errors = actionContext.ModelState.Where(u => u.Value.Errors.Count > 0)
                                                .SelectMany(u => u.Value.Errors)
                                                .Select(u => u.ErrorMessage).ToArray();

                var errorResult = new ErrorResult
                {
                    Source = null,
                    Exception = "Existen errores en la petición",
                    StatusCode = 400,
                    ErrorId = errorId,
                    SupportMessage = "Provide the ErrorId to the support team for further analysis."
                };
                errorResult.Errors = errors.ToList();

                Log.Error($"{errorResult.Exception} Request failed with Status Code 400 and Error Id {errorId}.");

                return new BadRequestObjectResult(errorResult);
            };
        });

        

        return services;
    }
       

    internal static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app) =>
        app.UseMiddleware<ExceptionMiddleware>();

}

