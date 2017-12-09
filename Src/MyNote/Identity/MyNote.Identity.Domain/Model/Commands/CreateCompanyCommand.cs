namespace MyNote.Identity.Domain.Model.Commands
{
    public class CreateCompanyCommand 
    {
        public string Name { get; set; }
        public string VatNumber { get; set; }
        public string RegistrationNumber { get; set; }
    }
}