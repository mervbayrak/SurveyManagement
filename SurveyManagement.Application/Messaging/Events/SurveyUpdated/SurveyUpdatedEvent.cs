using System;
namespace SurveyManagement.Application.Messaging.Events.SurveyUpdated
{
	public class SurveyUpdatedEvent
	{
        public Guid SurveyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

