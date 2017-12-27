using System;
using Marten;
using MediatR;

namespace MyNote.Infrastructure.Model.Domain
{
    public class DomainEventsService : IDomainEventsService
    {
        private readonly IDocumentSession _session;
        private readonly IMediator _mediator;
        private Marten.Events.IEventStore store => _session.Events;
        public DomainEventsService(IDocumentSession session, IMediator mediator)
        {
            if (session == null) throw new ArgumentNullException(nameof(session));
            if (mediator == null) throw new ArgumentNullException(nameof(mediator));
            _session = session;
            _mediator = mediator;
        }

        public void Save(IDomainEvent @event)
        {
            try
            {
                store.Append(@event.Id, @event);
                _session.SaveChanges();
                _mediator.Publish(@event);
            }
            catch (System.Exception ex)
            {

            }
          
        }
    }
}