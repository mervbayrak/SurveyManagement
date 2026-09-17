using System;
namespace SurveyManagement.Application.Abstractions.AI
{
	public interface IEmbeddingService
	{
        Task<float[]> CreateEmbeddingAsync(string text, CancellationToken cancellationToken = default);
    }
}

