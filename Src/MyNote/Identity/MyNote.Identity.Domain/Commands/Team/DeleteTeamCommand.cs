using System;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.Team
{
    public class DeleteTeamCommand : Command
    {
        public Guid Id { get; set; }
    }
}