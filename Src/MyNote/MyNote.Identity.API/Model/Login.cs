namespace MyNote.Identity.API.Model
{
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string Organization { get; set; }
    }
}