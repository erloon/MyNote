using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace MyNote.MVC.Models.VM
{
    public class CreateFiles
    {
        public Guid NoteId { get; set; }
        public List<IFormFile> Files { get; set; }
    }
}