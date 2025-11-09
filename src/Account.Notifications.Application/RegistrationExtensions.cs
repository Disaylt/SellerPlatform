using Account.Notifications.Application.Features.Notifications.Utilities.Abstraction;
using Account.Notifications.Application.Features.Notifications.Utilities.Implementation;
using Core.Application.Behaviors;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Account.Notifications.Application
{
    public static class RegistrationExtensions
    {
        public static IServiceCollection AddApplicationsServices(this IServiceCollection services)
        {
            services.AddSingleton<INotificationMapper, NotificationMapper>();

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

                cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
                cfg.AddOpenBehavior(typeof(FluentValidationBehavior<,>));
                cfg.AddOpenBehavior(typeof(DeepValidationBehavior<,>));
                cfg.AddOpenBehavior(typeof(TransactionBehavior<,>));
            });

            return services;
        }
    }
}
