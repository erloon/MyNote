using System;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.Resource
{
    public class RemoveResourceCommand : BaseCommand
    {
        public Guid Id { get; set; }
    }
}