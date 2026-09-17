using System;
using SurveyManagement.Application.Features.Surveys.Queries.SearchSurveys;

namespace SurveyManagement.Application.Abstractions.VectorDatabase
{
    public interface ISurveyVectorRepository
    {
        Task AddAsync(Guid surveyId, string title, string description, float[] embedding);

        Task<List<SearchSurveyResponse>> SearchAsync(float[] embedding, CancellationToken cancellationToken = default);
    }
}

