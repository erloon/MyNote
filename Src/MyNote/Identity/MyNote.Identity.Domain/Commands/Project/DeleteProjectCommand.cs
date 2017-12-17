using System;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.Project
{
    public class DeleteProjectCommand : BaseCommand
    {
        public Guid Id { get; set; }
    }
}