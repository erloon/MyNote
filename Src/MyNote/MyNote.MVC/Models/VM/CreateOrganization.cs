namespace MyNote.MVC.Models.VM
{
    public class CreateOrganization
    {
        public string Name { get; set; }
        public CreateCompany Company { get; set; }
        public CreateAddress Address { get; set; }

    }
}