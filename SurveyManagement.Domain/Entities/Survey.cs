using System;
namespace SurveyManagement.Domain.Entities
{
    public class Survey
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;

        public ICollection<SurveyQuestion> Questions { get; set; } = new List<SurveyQuestion>();
    }

}

