using System;
using MediatR;
using SurveyManagement.Domain.Common;

namespace SurveyManagement.Domain.Events
{
    public class SurveyCreatedDomainEvent : IDomainEvent, INotification
    {
        public Guid SurveyId { get; }
        public string Title { get; }
        public string Description { get; }

        public SurveyCreatedDomainEvent(Guid surveyId, string title, string description)
        {
            SurveyId = surveyId;
            Title = title;
            Description = description;
        }
    }
}

