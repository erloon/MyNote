using System;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.Organization
{
    public class DeleteOrganizationCommand : BaseCommand
    {
        public Guid Id { get; set; }
    }
}