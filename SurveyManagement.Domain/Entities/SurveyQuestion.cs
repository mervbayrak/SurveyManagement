using System;
namespace SurveyManagement.Domain.Entities
{
    public class SurveyQuestion
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid SurveyId { get; set; }
        public string QuestionText { get; set; } = null!;
        public int Order { get; set; }

        public ICollection<SurveyAnswerOption> Options { get; set; } = new List<SurveyAnswerOption>();
    }
}

