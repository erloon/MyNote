using System;
using MediatR;

namespace MyNote.Infrastructure.Model.Domain
{
    public interface ICommand : IRequest<bool>
    {
        Guid Id { get; }
        DateTime CreateDate { get; }
    }
}