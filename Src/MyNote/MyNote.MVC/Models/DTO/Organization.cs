using System;
using System.Collections.Generic;

namespace MyNote.MVC.Models.DTO
{
    public class Organization
    {
        public Guid Id { get;protected set; }
        public string Name { get; protected set; }
        public Address Address { get; protected set; }
        public Guid? AddressId { get; protected set; }
        public Guid? CompanyId { get; protected set; }
        public Company Company { get; protected set; }
        public virtual ICollection<Project> Projects { get; protected set; }
        public virtual ICollection<User> Users { get; protected set; }
        public virtual ICollection<Resource> Resources { get; protected set; }

        public Organization()
        {
        }
        
    }
}