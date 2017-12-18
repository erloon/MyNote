using System;
using Marten.Events;
using Marten.Events.Projections;

namespace MyNote.Identity.Domain.Events.User
{
    public class UserCreated 
    {
        public bool IsAdministrator { get; set; }
    }
}