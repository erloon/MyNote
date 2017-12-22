using System;
using Marten;

namespace MyNote.Infrastructure.Model.Domain
{
    public class DomainEventsService : IDomainEventsService
    {
        private readonly IDocumentSession _session;
        private Marten.Events.IEventStore store => _session.Events;
        public DomainEventsService(IDocumentSession session)
        {
            if (session == null) throw new ArgumentNullException(nameof(session));
            _session = session;
        }

        public void Save(IDomainEvent @event)
        {
            store.Append(@event.Id,@event);
            _session.SaveChanges();
        }
    }
}