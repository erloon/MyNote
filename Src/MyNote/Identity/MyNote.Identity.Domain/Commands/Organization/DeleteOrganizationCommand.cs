using System;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.Organization
{
    public class DeleteOrganizationCommand : Command
    {
        public Guid Id { get; set; }
    }
}