using System;
using System.Collections;
using Qdrant.Client;
using Qdrant.Client.Grpc;
using SurveyManagement.Application.Abstractions.VectorDatabase;
using SurveyManagement.Application.Features.Surveys.Queries.SearchSurveys;

namespace SurveyManagement.Infrastructure.VectorDatabase.Qdrant
{
    public class QdrantSurveyVectorRepository : ISurveyVectorRepository
    {
        private readonly QdrantClient _client;

        private const string CollectionName = "surveys";

        public QdrantSurveyVectorRepository(QdrantClient client)
        {
            _client = client;
        }

        public async Task AddAsync(Guid surveyId, string title, string description, float[] embedding)
        {
            try
            {
                await _client.UpsertAsync(CollectionName,
               new[]
               {
                new PointStruct
                {
                    Id = new PointId
                    {
                        Uuid = surveyId.ToString()
                    },

                    Vectors = new Vectors
                    {
                        Vector = new Vector
                        {
                            Data = { embedding }
                        }
                    },

                    Payload =
                    {
                        ["surveyId"] = surveyId.ToString(),
                        ["title"] = title,
                        ["description"] = description
                    }
                }
               });
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }

        public async Task<List<SearchSurveyResponse>> SearchAsync(float[] embedding, CancellationToken cancellationToken = default)
        {
            var results = await _client.SearchAsync(
                collectionName: CollectionName,
                vector: embedding,
                limit: 5,
                scoreThreshold : 0.60f,
                cancellationToken: cancellationToken);

            return results.Select(x => new SearchSurveyResponse
            {
                SurveyId = Guid.Parse(x.Payload["surveyId"].StringValue),
                Title = x.Payload["title"].StringValue,
                Description = x.Payload["description"].StringValue,
                Score = x.Score
            }).ToList();
        }
    }
}

