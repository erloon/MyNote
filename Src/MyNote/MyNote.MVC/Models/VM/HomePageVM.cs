namespace MyNote.MVC.Models.VM
{
    public class HomePageVM
    {
        public OrganizationContext OrganizationContext { get; set; }
        public CreateNote CreateNote { get; set; }
        public CreateProject CreateProject { get; set; }
        public CreateTeam CreateTeam { get; set; }
        public CreateFormFile ImageHeader { get; set; }
        public CreateFiles Files { get; set; }
        public CreateImages Images { get; set; }
    }
}