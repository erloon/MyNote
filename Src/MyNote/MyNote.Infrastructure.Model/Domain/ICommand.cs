using System;
using MediatR;

namespace MyNote.Infrastructure.Model.Domain
{
    public interface ICommand 
    {
        Guid? Id { get; }
        DateTime CreateDate { get; }
    }
}