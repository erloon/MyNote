using Microsoft.AspNetCore.Http;

namespace MyNote.MVC.Models.VM
{
    public class CreateFormFile
    {
        public string Name { get; set; }
        public IFormFile File { get; set; }

        public CreateFormFile()
        {
            
        }
    }
}