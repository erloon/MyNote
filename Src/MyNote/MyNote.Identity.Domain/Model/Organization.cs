using System;
using System.Collections.Generic;
using System.Net.Sockets;
using MyNote.Infrastructure.Model.Entity;

namespace MyNote.Identity.Domain.Model
{
    public class Organization :Aggregate
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public Company Company { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}