using System;
using OpenAI.Embeddings;
using SurveyManagement.Application.Abstractions.AI;

namespace SurveyManagement.Infrastructure.AI.OpenAI
{
    public class OpenAIEmbeddingService : IEmbeddingService
    {
        public Task<float[]> CreateEmbeddingAsync(string text, CancellationToken cancellationToken = default)
        {
            // Şimdilik gerçek OpenAI çağrısı yok
            return Task.FromResult(new float[1536]);
        }
    }

    //Ücretli olduğu için şuan bu sekilde kullanılmayacak
    //public class OpenAIEmbeddingService : IEmbeddingService
    //{
    //    private readonly EmbeddingClient _client;

    //    public OpenAIEmbeddingService(string apiKey)
    //    {
    //        _client = new EmbeddingClient("text-embedding-3-small", apiKey);
    //    }

    //    public async Task<float[]> CreateEmbeddingAsync(string text, CancellationToken cancellationToken = default)
    //    {
    //        var embedding = await _client.GenerateEmbeddingAsync(text, cancellationToken: cancellationToken);

    //        return embedding.Value.ToFloats().ToArray();
    //    }
    //}
}

