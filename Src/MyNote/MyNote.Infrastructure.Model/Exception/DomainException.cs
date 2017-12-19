using System;

namespace MyNote.Infrastructure.Model.Exception
{
    public class DomainException : System.Exception
    {
        public Guid AggregateId { get; set; }
        public DomainException(string message, Guid aggregateId) : base(message)
        {
            this.AggregateId = aggregateId;
        }
    }
}