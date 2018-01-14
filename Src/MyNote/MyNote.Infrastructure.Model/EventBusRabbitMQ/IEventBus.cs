using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Infrastructure.Model.EventBusRabbitMQ
{
    public interface IEventBus
    {
        void Subscribe<T, TH>()
            where T : DomainEvent
            where TH : IIntegrationEventHandler<T>;
        void SubscribeDynamic<TH>(string eventName)
            where TH : IDynamicIntegrationEventHandler;

        void UnsubscribeDynamic<TH>(string eventName)
            where TH : IDynamicIntegrationEventHandler;

        void Unsubscribe<T, TH>()
            where TH : IIntegrationEventHandler<T>
            where T : DomainEvent;

        void Publish(DomainEvent @event);
    }
}