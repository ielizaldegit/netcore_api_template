using API.Helpers;
using Core;
using FluentValidation.AspNetCore;
using Infrastructure;
using Infrastructure.Common;
using Microsoft.AspNetCore.Mvc;
using Serilog;

[assembly: ApiConventionType(typeof(SwApiConventions))]

StaticLogger.EnsureInitialized();
Log.Information("Server Booting Up...");


try {

    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((_, config) => {
        config.WriteTo.Console()
        .ReadFrom.Configuration(builder.Configuration);
    });

    builder.Services
        .AddControllers(options => { options.RespectBrowserAcceptHeader = true; })
        .AddJsonOptions(options => { options.JsonSerializerOptions.PropertyNamingPolicy = null; })
        .AddXmlDataContractSerializerFormatters();

    builder.Services.AddFluentValidationAutoValidation();
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddApplication(builder.Configuration);

    var app = builder.Build();
    await app.Services.InitializeDatabasesAsync();

    app.UseInfrastructure(builder.Configuration);
    app.MapControllers();
    app.Run();


}
catch (Exception ex) when (!ex.GetType().Name.Equals("StopTheHostException", StringComparison.Ordinal)) {
    StaticLogger.EnsureInitialized();
    Log.Fatal(ex, "Unhandled exception");
}
finally {
    StaticLogger.EnsureInitialized();
    Log.Information("Server Shutting down...");
    Log.CloseAndFlush();
}







