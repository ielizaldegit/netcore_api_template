using System;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Infrastructure.Persistence;

internal static class Startup
{
    private static readonly ILogger _logger = Log.ForContext(typeof(Startup));

    internal static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration config)
    {
        var databaseSettings = config.GetSection(nameof(DatabaseSettings)).Get<DatabaseSettings>();
        string rootConnectionString = databaseSettings.ConnectionString;
        if (string.IsNullOrEmpty(rootConnectionString))
        {
            throw new InvalidOperationException("DB ConnectionString is not configured.");
        }

        string dbProvider = databaseSettings.DBProvider;
        if (string.IsNullOrEmpty(dbProvider))
        {
            throw new InvalidOperationException("DB Provider is not configured.");
        }

        _logger.Information($"Current DB Provider : {dbProvider}");

        return services
            .Configure<DatabaseSettings>(config.GetSection(nameof(DatabaseSettings)))
            .AddDbContext<ApplicationDbContext>(m => m.UseDatabase(dbProvider, rootConnectionString))
            .AddTransient<ApplicationDbInitializer>();
            //.AddRepositories();
    }

    internal static DbContextOptionsBuilder UseDatabase(this DbContextOptionsBuilder builder, string dbProvider, string connectionString)
    {
        switch (dbProvider.ToLowerInvariant())
        {
            case "postgresql":
                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
                return null;// builder.UseNpgsql(connectionString, e => e.MigrationsAssembly("Migrators.PostgreSQL"));

            case "mssql":
                return builder.UseSqlServer(connectionString, e => e.MigrationsAssembly("Infrastructure.Migrator.MSSQL"));

            case "mysql":
                return null; //builder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), e =>
                     //e.MigrationsAssembly("Migrators.MySQL").SchemaBehavior(MySqlSchemaBehavior.Ignore));

            case "oracle":
                return null;// builder.UseOracle(connectionString, e => e.MigrationsAssembly("Migrators.Oracle"));

            default:
                throw new InvalidOperationException($"DB Provider {dbProvider} is not supported.");
        }
    }

    //private static IServiceCollection AddRepositories(this IServiceCollection services)
    //{
    //    // Add Repositories
    //    services.AddScoped(typeof(IRepository<>), typeof(ApplicationDbRepository<>));

    //    foreach (var aggregateRootType in
    //        typeof(IAggregateRoot).Assembly.GetExportedTypes()
    //            .Where(t => typeof(IAggregateRoot).IsAssignableFrom(t) && t.IsClass)
    //            .ToList())
    //    {
    //        // Add ReadRepositories.
    //        services.AddScoped(typeof(IReadRepository<>).MakeGenericType(aggregateRootType), sp =>
    //            sp.GetRequiredService(typeof(IRepository<>).MakeGenericType(aggregateRootType)));

    //        // Decorate the repositories with EventAddingRepositoryDecorators and expose them as IRepositoryWithEvents.
    //        services.AddScoped(typeof(IRepositoryWithEvents<>).MakeGenericType(aggregateRootType), sp =>
    //            Activator.CreateInstance(
    //                typeof(EventAddingRepositoryDecorator<>).MakeGenericType(aggregateRootType),
    //                sp.GetRequiredService(typeof(IRepository<>).MakeGenericType(aggregateRootType)))
    //            ?? throw new InvalidOperationException($"Couldn't create EventAddingRepositoryDecorator for aggregateRootType {aggregateRootType.Name}"));
    //    }

    //    return services;
    //}
}

