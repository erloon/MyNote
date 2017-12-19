using MyNote.Identity.Domain.Commands.Company;
using MyNote.Infrastructure.Model;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.Organization
{
    public class CreateOrganizationCommand : Command
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public CreateCompanyCommand CreateCompanyCommand { get; set; }
    }
}