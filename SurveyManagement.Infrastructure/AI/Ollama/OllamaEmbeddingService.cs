using System;
using System.Net.Http;
using System.Net.Http.Json;
using SurveyManagement.Application.Abstractions.AI;

namespace SurveyManagement.Infrastructure.AI.Ollama
{
    public class OllamaEmbeddingService : IEmbeddingService
	{
        private readonly HttpClient _httpClient;

        public OllamaEmbeddingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<float[]> CreateEmbeddingAsync(string text, CancellationToken cancellationToken = default)
        {
            var request = new
            {
                model = "bge-m3",
                input = text
            };

            var response = await _httpClient.PostAsJsonAsync(
                "/api/embed",
                request,
                cancellationToken);

            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadFromJsonAsync<OllamaEmbeddingResponse>(
                    cancellationToken: cancellationToken);

            return result!.Embeddings[0];
        }
    }
}

