using System;
using SurveyManagement.Domain.Common;
using SurveyManagement.Domain.Entities;

namespace SurveyManagement.Domain.Events
{
    public class SurveyCreatedDomainEvent : IDomainEvent
    {
        public Survey Survey { get; }

        public SurveyCreatedDomainEvent(Survey survey)
        {
            Survey = survey;
        }
    }

}

