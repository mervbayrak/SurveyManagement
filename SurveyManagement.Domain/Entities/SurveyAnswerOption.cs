namespace SurveyManagement.Domain.Entities
{
    public class SurveyAnswerOption
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid QuestionId { get; set; }
        public string Text { get; set; } = null!;
        public int Order { get; set; }
    }

}

