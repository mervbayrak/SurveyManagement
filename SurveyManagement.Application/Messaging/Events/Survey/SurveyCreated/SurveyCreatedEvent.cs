using System;
namespace SurveyManagement.Application.Messaging.Events.SurveyCreated
{
    public class SurveyCreatedEvent
    {
        public Guid SurveyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

