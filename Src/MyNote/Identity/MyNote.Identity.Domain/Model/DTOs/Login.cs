namespace MyNote.Identity.Domain.Model.DTOs
{
    public class Login
    {

        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string Organization { get; set; }
        public string ReturnUrl { get; set; }
    }
}