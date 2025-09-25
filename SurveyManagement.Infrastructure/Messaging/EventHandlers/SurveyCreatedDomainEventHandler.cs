using System;
using MediatR;
using SurveyManagement.Application.Messaging.Events.SurveyCreated;
using SurveyManagement.Application.Messaging.Interfaces;
using SurveyManagement.Domain.Events;

namespace SurveyManagement.Infrastructure.Messaging.EventHandlers
{
    public class SurveyCreatedDomainEventHandler : INotificationHandler<SurveyCreatedDomainEvent>
    {
        private readonly IEventPublisher _eventPublisher;

        public SurveyCreatedDomainEventHandler(IEventPublisher eventPublisher)
        {
            _eventPublisher = eventPublisher;
        }

        public async Task Handle(SurveyCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            // Domain event → Integration event mapping
            var integrationEvent = new SurveyCreatedEvent
            {
                SurveyId = notification.SurveyId,
                Title = notification.Title,
                Description = "" // domain event’te yoksa boş geçilebilir
            };

            _eventPublisher.Publish(integrationEvent);

        }
    }

}

