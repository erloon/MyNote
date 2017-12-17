using System;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.Team
{
    public class DeleteTeamCommand : BaseCommand
    {
        public Guid Id { get; set; }
    }
}