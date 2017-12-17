using System;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.Company
{
    public class AddAddressToCompanyCommand : BaseCommand
    {
        public Guid CompanyId { get; set; }
        public Guid AddressId { get; set; }

    }
}