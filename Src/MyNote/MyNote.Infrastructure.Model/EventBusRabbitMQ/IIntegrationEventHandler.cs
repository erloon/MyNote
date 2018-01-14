using System.Threading.Tasks;
using MyNote.Infrastructure.Model.Domain;


namespace MyNote.Infrastructure.Model.EventBusRabbitMQ
{
    public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler
        where TIntegrationEvent : DomainEvent
    {
        Task Handle(TIntegrationEvent @event);
      
    }
    public interface IIntegrationEventHandler
    {
    }
}