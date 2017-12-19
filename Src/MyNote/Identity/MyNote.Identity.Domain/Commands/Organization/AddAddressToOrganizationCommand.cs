using System;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.Organization
{
    public class AddAddressToOrganizationCommand : Command
    {
        public Guid CompanyId { get; set; }
        public Guid AddressId { get; set; }
    }
}