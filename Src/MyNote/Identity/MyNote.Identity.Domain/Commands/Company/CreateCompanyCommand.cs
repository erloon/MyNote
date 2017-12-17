namespace MyNote.Identity.Domain.Commands.Company
{
    public class CreateCompanyCommand 
    {
        public string Name { get; set; }
        public string VatNumber { get; set; }
        public string RegistrationNumber { get; set; }
    }
}