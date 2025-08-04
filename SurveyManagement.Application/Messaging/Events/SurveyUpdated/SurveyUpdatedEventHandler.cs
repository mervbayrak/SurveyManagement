using System;
using SurveyManagement.Application.Messaging.Interfaces;

namespace SurveyManagement.Application.Messaging.Events.SurveyUpdated
{
    public class SurveyUpdatedEventHandler : IEventHandler<SurveyUpdatedEvent>, IEventHandlerMarker
    {
        public Task HandleAsync(SurveyUpdatedEvent @event)
        {
            Console.WriteLine($"Survey Update: {@event.Title}");
            return Task.CompletedTask;
        }
    }
}

