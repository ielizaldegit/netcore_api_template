using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NJsonSchema.Generation.TypeMappers;
using NSwag;
using NSwag.AspNetCore;
using NSwag.Generation.AspNetCore;
using NSwag.Generation.Processors.Security;

namespace Infrastructure.OpenApi;

internal static class Startup
{
    internal static IServiceCollection AddOpenApiDocumentation(this IServiceCollection services, IConfiguration config)
    {
        var settings = config.GetSection(nameof(SwaggerSettings)).Get<SwaggerSettings>();
        if (settings.Enable) {

            services.AddEndpointsApiExplorer();

            var provider = services.BuildServiceProvider().GetService<IApiVersionDescriptionProvider>();

            foreach (var description in provider.ApiVersionDescriptions)
            {
                services.AddOpenApiDocument((document, serviceProvider) =>
                {
                    document.DocumentName = "v" + description.ApiVersion.ToString();
                    document.PostProcess = doc =>
                    {
                        doc.Info.Title = settings.Title;
                        doc.Info.Version = "v" + description.ApiVersion.ToString();
                        doc.Info.Description = settings.Description;
                        doc.Info.Contact = new() {
                            Name = settings.ContactName,
                            Email = settings.ContactEmail,
                            Url = settings.ContactUrl
                        };
                        doc.Info.License = new() {
                            Name = settings.LicenseName,
                            Url = settings.LicenseUrl
                        };

                    };
                    document.ApiGroupNames = new[] { description.ApiVersion.ToString()};
                });
            }
        }

        return services;
    }

    internal static IApplicationBuilder UseOpenApiDocumentation(this IApplicationBuilder app, IConfiguration config)
    {

        if (config.GetValue<bool>("SwaggerSettings:Enable")) {
            app.UseOpenApi(options =>
            {
                options.Path = "/docs/{documentName}/docs.json";
            });
            app.UseSwaggerUi3(options =>
            {
                options.Path = "/docs";
                options.DocumentPath = "/docs/{documentName}/docs.json";
                options.DocumentTitle = config.GetValue<string>("SwaggerSettings:Title");
                options.DefaultModelsExpandDepth = -1;
                options.DocExpansion = "none";
                options.TagsSorter = "alpha";
                options.CustomStylesheetPath = "/swagger-ui/custom.css/";

            });
        }

        return app;
    }

}

