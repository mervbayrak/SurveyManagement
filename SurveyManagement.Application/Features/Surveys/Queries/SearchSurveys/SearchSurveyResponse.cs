namespace SurveyManagement.Application.Features.Surveys.Queries.SearchSurveys
{
    public class SearchSurveyResponse
    {
        public Guid SurveyId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public float Score { get; set; }
    }
}