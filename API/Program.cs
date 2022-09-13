using System.Reflection;
using API.Extensions;
using AspNetCoreRateLimit;
using Infrastructure;
using Infrastructure.Common;
using Serilog;



StaticLogger.EnsureInitialized();
Log.Information("Server Booting Up...");


try {

    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((_, config) => {
        config.WriteTo.Console()
        .ReadFrom.Configuration(builder.Configuration);
    });


    builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());

    builder.Services.AddAplicacionServices();

    builder.Services
        .AddControllers(options => {
            options.RespectBrowserAcceptHeader = true;
            options.ReturnHttpNotAcceptable = true;
        })
        .AddJsonOptions(options => { options.JsonSerializerOptions.PropertyNamingPolicy = null;})
        .AddXmlDataContractSerializerFormatters();

    builder.Services.AddInfrastructure(builder.Configuration);



    var app = builder.Build();
    //app.UseStatusCodePagesWithReExecute("/errors/{0}");
    await app.Services.InitializeDatabasesAsync();

    app.UseInfrastructure(builder.Configuration);
    app.MapControllers();
    app.Run();


}
catch (Exception ex) when (!ex.GetType().Name.Equals("StopTheHostException", StringComparison.Ordinal))
{
    StaticLogger.EnsureInitialized();
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    StaticLogger.EnsureInitialized();
    Log.Information("Server Shutting down...");
    Log.CloseAndFlush();
}







