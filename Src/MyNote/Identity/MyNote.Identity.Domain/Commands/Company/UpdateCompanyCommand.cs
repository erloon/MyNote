using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.Company
{
    public class UpdateCompanyCommand : BaseCommand
    {
        public string Name { get; set; }
        public string VatNumber { get; set; }
        public string RegistrationNumber { get; set; }
    }
}