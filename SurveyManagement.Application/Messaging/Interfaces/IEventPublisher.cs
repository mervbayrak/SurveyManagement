namespace SurveyManagement.Application.Messaging.Interfaces
{
    public interface IEventPublisher
    {
        Task Publish<T>(T message) where T : class;
    }
}

