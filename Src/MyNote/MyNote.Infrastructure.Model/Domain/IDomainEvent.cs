using System;

namespace MyNote.Infrastructure.Model.Domain
{
    public interface IDomainEvent
    {
        string  Payload { get; set; }
        Guid AggregateId { get; set; }
        string Type { get; set; }
        string PayloadType { get; set; }

    }
}