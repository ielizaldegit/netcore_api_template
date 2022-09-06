using System.Reflection;
using API.Extensions;
using API.Helpers.Errors;
using AspNetCoreRateLimit;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(builder.Configuration)
                    .Enrich.FromLogContext()
                    .CreateLogger();

//builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
builder.Services.ConfigureRateLimit(builder.Configuration);


builder.Services.ConfigureCors();
builder.Services.AddAplicacionServices();
//builder.Services.ConfigureApiVersioning();
builder.Services.AddJwt(builder.Configuration);


builder.Services
    .AddControllers(options => {
        options.RespectBrowserAcceptHeader = true;
        options.ReturnHttpNotAcceptable = true;
    })
    .AddJsonOptions(options => {
         options.JsonSerializerOptions.PropertyNamingPolicy = null;
    })
    .AddXmlDataContractSerializerFormatters();

builder.Services.AddValidationErrors();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();


var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.UseStatusCodePagesWithReExecute("/errors/{0}");
app.UseIpRateLimiting();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger(options =>
    {
        options.RouteTemplate = "docs/{documentName}/docs.json";
    });
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/docs/v1/docs.json", "My API V1");

        options.RoutePrefix = "docs";
        options.DocumentTitle = "SW API";
        options.InjectStylesheet("/swagger-ui/custom.css");
    });
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        await context.Database.MigrateAsync();
    }
    catch (Exception ex)
    {
        var _logger = loggerFactory.CreateLogger<Program>();
        _logger.LogError(ex, "Ocurrió un error durante la migración");
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors();
app.MapControllers();
app.Run();
