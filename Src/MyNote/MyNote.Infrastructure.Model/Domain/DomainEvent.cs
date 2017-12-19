using System;

namespace MyNote.Infrastructure.Model.Domain
{
    public abstract class DomainEvent : IDomainEvent
    {
        public DomainEvent()
        {
            this.CreateDate = DateTime.Now;
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; }
        public DateTime CreateDate { get; }
    }
}