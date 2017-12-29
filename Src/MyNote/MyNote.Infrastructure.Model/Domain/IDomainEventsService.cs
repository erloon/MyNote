using MediatR;

namespace MyNote.Infrastructure.Model.Domain
{
    public interface IDomainEventsService
    {
        void Save(DomainEvent @event);
        void Publish(INotification notification);
    }
}