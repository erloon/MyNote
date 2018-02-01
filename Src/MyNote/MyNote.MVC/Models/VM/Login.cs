using System.ComponentModel.DataAnnotations;

namespace MyNote.MVC.Models.VM
{
    public class Login
    {
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string Organization { get; set; }

        public Login()
        {
            
        }

        public Login(RegisterUser registerUser)
        {
            this.Password = registerUser.Password;
            this.Email = registerUser.Email;
            this.Organization = registerUser.Organization;
        }
    }
}