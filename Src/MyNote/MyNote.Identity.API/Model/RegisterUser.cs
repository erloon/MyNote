namespace MyNote.Identity.API.Model
{
    public class RegisterUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}