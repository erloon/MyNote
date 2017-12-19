using System;
using System.Collections.Generic;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Infrastructure.Model.Entity
{
    public class Aggregate: BaseEntity
    {
        public byte[] Timestamp { get; set; }

        public Queue<IDomainEvent> Events { get; private set; }

        protected Aggregate()
        {
            this.Events =  new Queue<IDomainEvent>();
        }

        protected void Append(IDomainEvent @event)
        {
            this.Events.Enqueue(@event);
        }
    }
}