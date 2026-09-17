using SurveyManagement.Application.Abstractions.AI;
using SurveyManagement.Application.Abstractions.VectorDatabase;
using SurveyManagement.Application.Messaging.Interfaces;

namespace SurveyManagement.Application.Messaging.Events.SurveyCreated
{
    public class SurveyCreatedEventHandler : IEventHandler<SurveyCreatedEvent>, IEventHandlerMarker
    {
        private readonly IEmbeddingService _embeddingService;
        private readonly ISurveyVectorRepository _vectorRepository;

        public SurveyCreatedEventHandler(IEmbeddingService embeddingService, ISurveyVectorRepository vectorRepository)
        {
            _embeddingService = embeddingService;
            _vectorRepository = vectorRepository;
        }

        public async Task HandleAsync(SurveyCreatedEvent @event)
        {
            var text = $"{@event.Title}. {@event.Description}";

            var embedding = await _embeddingService.CreateEmbeddingAsync(text);

            await _vectorRepository.AddAsync(@event.SurveyId, @event.Title, @event.Description, embedding);
        }
    }
}

