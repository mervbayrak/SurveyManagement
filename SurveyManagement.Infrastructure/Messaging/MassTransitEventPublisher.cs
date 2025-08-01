using System;
using MassTransit;
using SurveyManagement.Application.Messaging.Interfaces;

namespace SurveyManagement.Infrastructure.Messaging
{
    public class MassTransitEventPublisher : IEventPublisher
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public MassTransitEventPublisher(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public Task Publish<T>(T message) where T : class
        {
            return _publishEndpoint.Publish(message);
        }
    }

}