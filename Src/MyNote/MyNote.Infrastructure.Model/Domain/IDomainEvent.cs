using System;
using MediatR;

namespace MyNote.Infrastructure.Model.Domain
{
    public interface IDomainEvent
    {
        Guid Id { get; }
        DateTime CreateDate { get; }
    }
}