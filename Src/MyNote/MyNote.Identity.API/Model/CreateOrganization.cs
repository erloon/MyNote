namespace MyNote.Identity.API.Model
{
    public class CreateOrganization
    {
        public string Name { get; set; }
        public CreateCompany Company { get; set; }
        public CreateAddress Address { get; set; }

    }
}