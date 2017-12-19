using System;
using MediatR;

namespace MyNote.Infrastructure.Model.Domain
{
    public interface IDomainEvent : INotification
    {
        Guid Id { get; }
        DateTime CreateDate { get; }
    }
}