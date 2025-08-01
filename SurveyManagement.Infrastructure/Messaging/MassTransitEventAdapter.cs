using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using SurveyManagement.Application.Messaging.Interfaces;

namespace SurveyManagement.Infrastructure.Messaging
{
    public class MassTransitEventAdapter<TEvent> : IConsumer<TEvent> where TEvent : class
    {
        private readonly IServiceProvider _serviceProvider;

        public MassTransitEventAdapter(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Consume(ConsumeContext<TEvent> context)
        {
            var handler = _serviceProvider.GetService<IEventHandler<TEvent>>();

            if (handler != null)
            {
                await handler.HandleAsync(context.Message);
            }
            else
            {
                // Log ya da fallback strateji uygulayabilirsin
                throw new InvalidOperationException($"No handler registered for {typeof(TEvent).Name}");
            }
        }
    }
}