using System;
using System.Collections.Generic;

namespace MyNote.Identity.Domain
{
    public class OrganizationContext
    {
        public Guid OrganizationId { get; set; }
        public Guid UserId { get; set; }
        public List<Guid> TeamsOwnership { get; set; }
        public List<Guid> ProjectsOwnership { get; set; }
    }
}