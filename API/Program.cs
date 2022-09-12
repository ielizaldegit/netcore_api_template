using System.Reflection;
using API.Extensions;
using AspNetCoreRateLimit;
using Infrastructure;
using Infrastructure.Common;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Serilog;



StaticLogger.EnsureInitialized();
Log.Information("Server Booting Up...");


try
{


    var builder = WebApplication.CreateBuilder(args);

    //var logger = new LoggerConfiguration()
    //                    .ReadFrom.Configuration(builder.Configuration)
    //                    .Enrich.FromLogContext()
    //                    .CreateLogger();

    ////builder.Logging.ClearProviders();
    //builder.Logging.AddSerilog(logger);

    builder.Host.UseSerilog((_, config) =>
    {
        config.WriteTo.Console()
        .ReadFrom.Configuration(builder.Configuration);
    });



    builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
    builder.Services.ConfigureRateLimit(builder.Configuration);


    //builder.Services.ConfigureCors();
    builder.Services.AddAplicacionServices();
    //builder.Services.ConfigureApiVersioning();


    //builder.Services.AddJwt(builder.Configuration);


    builder.Services
        .AddControllers(options => {
            options.RespectBrowserAcceptHeader = true;
            options.ReturnHttpNotAcceptable = true;
        })
        .AddJsonOptions(options => {
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
        })
        .AddXmlDataContractSerializerFormatters();

    builder.Services.AddInfrastructure(builder.Configuration);


    //builder.Services.AddValidationErrors();





    //builder.Services.AddDbContext<ApplicationDbContext>(options =>
    //{
    //    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), e => e.MigrationsAssembly("Infrastructure.Migrator.MSSQL"));
    //});








    //builder.Services.AddEndpointsApiExplorer();
    //builder.Services.ConfigureSwagger();


    var app = builder.Build();

    //app.UseMiddleware<ExceptionMiddleware>();
    //app.UseStatusCodePagesWithReExecute("/errors/{0}");

    await app.Services.InitializeDatabasesAsync();

    app.UseIpRateLimiting();

    //if (app.Environment.IsDevelopment())
    //{
    //    app.UseSwagger(options =>
    //    {
    //        options.RouteTemplate = "docs/{documentName}/docs.json";
    //    });
    //    app.UseSwaggerUI(options =>
    //    {
    //        options.SwaggerEndpoint("/docs/v1/docs.json", "My API V1");

    //        options.RoutePrefix = "docs";
    //        options.DocumentTitle = "SW API";
    //        options.InjectStylesheet("/swagger-ui/custom.css");
    //    });
    //}



    //using (var scope = app.Services.CreateScope())
    //{
    //    var services = scope.ServiceProvider;
    //    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    //    try
    //    {
    //        var context = services.GetRequiredService<ApplicationDbContext>();
    //        await context.Database.MigrateAsync();
    //    }
    //    catch (Exception ex)
    //    {
    //        var _logger = loggerFactory.CreateLogger<Program>();
    //        _logger.LogError(ex, "Ocurrió un error durante la migración");
    //    }
    //}




    //app.UseHttpsRedirection();
    //app.UseStaticFiles();
    //app.UseAuthentication();
    //app.UseAuthorization();
    app.UseInfrastructure(builder.Configuration);
    //app.UseCors();
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







