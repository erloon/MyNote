namespace MyNote.Infrastructure.Model.Domain
{
    public interface IDomainEventsService
    {
        void Save(IDomainEvent @event);
    }
}