using System;
using MediatR;

namespace MyNote.Infrastructure.Model.Domain
{
    public abstract class DomainEvent : IDomainEvent, INotification
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