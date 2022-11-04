using System.Reflection;
using Core.Application.Common.ExternalServices;
using Core.Domain.Interfaces.Services;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core
{
    public static class Startup
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration config)
        {

            services.AddSingleton<INotificationService, NotificationService>();
            services.AddHttpClient("NotificationApi", c => c.BaseAddress = new Uri(config.GetValue<string>("ExternalServices:Notification:BaseAddress") ));
            services.AddSingleton<IStorageService, StorageService>();
            services.AddHttpClient("StorageApi", c => c.BaseAddress = new Uri(config.GetValue<string>("ExternalServices:Storage:BaseAddress")));




            var assembly = Assembly.GetExecutingAssembly();
            return services.AddValidatorsFromAssembly(assembly);
        }
    }
}

