using MediatR;
using SurveyManagement.Application.Abstractions.AI;
using SurveyManagement.Application.Abstractions.VectorDatabase;

namespace SurveyManagement.Application.Features.Surveys.Queries.SearchSurveys
{
    public class SearchSurveysQueryHandler : IRequestHandler<SearchSurveysQuery, List<SearchSurveyResponse>>
    {
        private readonly IEmbeddingService _embeddingService;
        private readonly ISurveyVectorRepository _vectorRepository;

        public SearchSurveysQueryHandler(IEmbeddingService embeddingService, ISurveyVectorRepository vectorRepository)
        {
            _embeddingService = embeddingService;
            _vectorRepository = vectorRepository;
        }

        public async Task<List<SearchSurveyResponse>> Handle(SearchSurveysQuery request, CancellationToken cancellationToken)
        {
            var embedding = await _embeddingService.CreateEmbeddingAsync(
                request.Query,
                cancellationToken);

            var results = await _vectorRepository.SearchAsync(
                embedding,
                cancellationToken);

            return results;
        }
    }
}