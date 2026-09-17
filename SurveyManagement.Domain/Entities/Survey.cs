using System;
using SurveyManagement.Domain.Common;
using SurveyManagement.Domain.Events;

namespace SurveyManagement.Domain.Entities
{
    public class Survey : AggregateRoot
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; set; } 
        public bool IsActive { get; set; }

        private Survey() { } // EF için

        private Survey(string title, string description)
        {
            Title = title;
            Description = description;
            CreatedAt = DateTime.UtcNow;
            IsActive = true;
            AddDomainEvent(new SurveyCreatedDomainEvent(Id, title, description));
        }

        public static Survey Create(string title, string description)
        {
            return new Survey(title, description);
        }
    }

}

