using System;

namespace MyNote.Infrastructure.Model.Exceptions
{
    public class DomainException : Exception
    {
        public Guid AggregateId { get; set; }
        public DomainException(string message, Guid aggregateId) : base(message)
        {
            this.AggregateId = aggregateId;
        }
    }
}