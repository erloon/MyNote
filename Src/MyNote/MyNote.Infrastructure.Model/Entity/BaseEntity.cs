using System;
using System.Collections.Generic;
using MediatR;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Infrastructure.Model.Entity
{
    public abstract class BaseEntity
    {
        
        protected BaseEntity()
        {
            this.Events = new Queue<IDomainEvent>();
        }
        public Queue<IDomainEvent> Events { get; private set; }
        protected void Save(IDomainEvent @event, IDomainEventsService domainEventsService)
        {
            this.Events.Enqueue(@event);
            domainEventsService.Save(@event);
        }

        public Guid Id { get; set; }
        public DateTime Create { get; set; }
        public DateTime Modification { get; set; }
        public Guid CreateBy { get; set; }
        public Guid UpdateBy { get; set; }

    }
}