using MyNote.Infrastructure.Model;

namespace MyNote.Identity.Domain.Model.Commands
{
    public class CreateOrganizationCommand :ICommand
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public CreateCompanyCommand CreateCompanyCommand { get; set; }
        
    }
}