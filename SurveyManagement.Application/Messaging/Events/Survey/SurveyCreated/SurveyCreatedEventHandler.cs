using SurveyManagement.Application.Messaging.Interfaces;

namespace SurveyManagement.Application.Messaging.Events.SurveyCreated
{
    public class SurveyCreatedEventHandler : IEventHandler<SurveyCreatedEvent>, IEventHandlerMarker
    {
        public Task HandleAsync(SurveyCreatedEvent @event)
        {
            Console.WriteLine($"Survey created: {@event.Title}");
            return Task.CompletedTask;
        }
    }
}

