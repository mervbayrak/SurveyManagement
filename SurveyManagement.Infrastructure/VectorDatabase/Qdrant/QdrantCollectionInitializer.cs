using System;
using Qdrant.Client;
using Qdrant.Client.Grpc;

namespace SurveyManagement.Infrastructure.VectorDatabase.Qdrant
{
    public class QdrantCollectionInitializer
    {
        private readonly QdrantClient _client;

        public QdrantCollectionInitializer(QdrantClient client)
        {
            _client = client;
        }

        public async Task InitializeAsync()
        {
            const string collectionName = "surveys";

            var collections = await _client.ListCollectionsAsync();

            if (collections.Contains(collectionName))
                return;

            await _client.CreateCollectionAsync(
                collectionName,
                new VectorParams
                {
                    Size = 1024,
                    Distance = Distance.Cosine
                });
        }
    }
}

