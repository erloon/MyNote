using System;
using MyNote.Identity.Domain.Commands.Address;
using MyNote.Identity.Domain.Commands.Company;
using MyNote.Identity.Domain.Commands.Organization;

namespace MyNote.Identity.Test.Factories
{
    public class OrganizationFactory
    {
        private static readonly Guid _userId = Guid.Parse("21BEBE7F-E1B4-4649-B386-10130EC0E332");
        public static CreateOrganizationCommand CreateCommand()
        {
            return new CreateOrganizationCommand()
            {
                Address = new CreateAddressCommand()
                {
                    City = "Warszawa",
                    Country = "Polska",
                    CreateBy = _userId,
                    Number = "5",
                    Street = "Wolska",
                    UpdateBy = _userId,
                },
                Company = new CreateCompanyCommand()
                {
                    Address = new CreateAddressCommand()
                    {
                        City = "Warszawa",
                        Country = "Polska",
                        CreateBy = _userId,
                        Street = "Cieszyńska",
                        UpdateBy = _userId
                    },
                    Name = "Nowa firma 1",
                    CreateBy = _userId,
                    RegistrationNumber = "145236987",
                    UpdateBy = _userId,
                    VatNumber = "456987123"
                },
                CreateBy = _userId,
                Name = "Nowa organizacja",
                UpdateBy = _userId
            };

        }
    }
}