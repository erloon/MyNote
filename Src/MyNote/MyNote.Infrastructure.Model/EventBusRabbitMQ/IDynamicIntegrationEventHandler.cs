using System.Threading.Tasks;

namespace MyNote.Infrastructure.Model.EventBusRabbitMQ
{
    public interface IDynamicIntegrationEventHandler
    {
        Task Handle(dynamic eventData);
    }
}