namespace MyNote.MVC.Models.VM
{
    public class NewOrganization
    {
        public CreateOrganization Organization { get; set; }
        public CreateAddress Address { get; set; }
        public CreateCompany Company { get; set; }
    }
}