using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace MyNote.MVC.Models.VM
{
    public class CreateImages
    {
        public List<IFormFile> Images { get; set; }

        public CreateImages()
        {
            
        }
    }
}