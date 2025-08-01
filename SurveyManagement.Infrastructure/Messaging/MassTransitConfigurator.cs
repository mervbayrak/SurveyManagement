using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using SurveyManagement.Application.Common.Extensions;
using SurveyManagement.Application.Messaging.Interfaces;

namespace SurveyManagement.Infrastructure.Messaging
{
    public static class MassTransitConfigurator
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration, Assembly markerAssembly)
        {
            services.AddMassTransit(x =>
            {
                var handlerTypes = markerAssembly
                    .GetTypes()
                    .Where(t => !t.IsAbstract && !t.IsInterface && typeof(IEventHandlerMarker).IsAssignableFrom(t))
                    .ToList();

                foreach (var handlerType in handlerTypes)
                {
                    var eventType = handlerType
                        .GetInterfaces()
                        .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEventHandler<>))
                        .GetGenericArguments()[0];

                    var adapterType = typeof(MassTransitEventAdapter<>).MakeGenericType(eventType);
                    x.AddConsumer(adapterType);
                }

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(configuration["RabbitMQ:Host"] ?? "rabbitmq://localhost", h =>
                    {
                        h.Username(configuration["RabbitMQ:Username"] ?? "guest");
                        h.Password(configuration["RabbitMQ:Password"] ?? "guest");
                    });

                    foreach (var handlerType in handlerTypes)
                    {
                        var eventType = handlerType
                            .GetInterfaces()
                            .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEventHandler<>))
                            .GetGenericArguments()[0];

                        var adapterType = typeof(MassTransitEventAdapter<>).MakeGenericType(eventType);
                        var queueName = eventType.Name.ToKebabCase();

                        cfg.ReceiveEndpoint(queueName, e =>
                        {
                            e.ConfigureConsumer(context, adapterType);
                            e.UseMessageRetry(r => r.Interval(3, TimeSpan.FromSeconds(5)));
                        });
                    }
                });
            });
        }
    }
}
