using System;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.Resource
{
    public class RemoveResourceCommand : Command
    {
        public Guid Id { get; set; }
    }
}