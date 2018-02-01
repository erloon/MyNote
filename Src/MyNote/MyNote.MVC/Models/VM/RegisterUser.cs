namespace MyNote.MVC.Models.VM
{
    public class RegisterUser
    {
        public string Email { get; set; }
        public string Organization { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool FirstOrganization { get; set; }
    }
}