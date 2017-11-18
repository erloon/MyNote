using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using MyNote.Identity.Domain.Model.Commands;
using MyNote.Infrastructure.Model.Entity;

namespace MyNote.Identity.Domain.Model
{
    public class Organization : Aggregate
    {
        public string Name { get; set; }
        public Guid AddressId { get; set; }
        public Address Address { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }

        public void AddUser(CreateUserCommand command, AspNetUserManager<ApplicationUser> userManager)
        {
            
        }

        public void Create(CreateOrganizationCommand command)
        {
            throw new NotImplementedException();
        }
    }
}