using System;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.Team
{
    public class CreateTeamCommand : BaseCommand
    {
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid OwnerId { get; set; }
    }
}