namespace MyNote.Identity.Domain.Model.Commands.User
{
    public class RegisterUserCommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Organization { get; set; }
    }
}