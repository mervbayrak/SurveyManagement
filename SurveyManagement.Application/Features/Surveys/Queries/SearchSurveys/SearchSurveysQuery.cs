using MediatR;

namespace SurveyManagement.Application.Features.Surveys.Queries.SearchSurveys
{
    public class SearchSurveysQuery : IRequest<List<SearchSurveyResponse>>
    {
        public string Query { get; set; } = string.Empty;
    }
}