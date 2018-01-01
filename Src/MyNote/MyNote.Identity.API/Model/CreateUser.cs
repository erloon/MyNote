using System;

namespace MyNote.Identity.API.Model
{
    public class CreateUser
    {
        public string UserName { get; set; }
        public bool IsAdministrator { get; set; }
    }
}