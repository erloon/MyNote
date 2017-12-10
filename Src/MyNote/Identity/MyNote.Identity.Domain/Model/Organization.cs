using System;
using System.Collections.Generic;
using MyNote.Identity.Domain.Model.Commands;
using MyNote.Infrastructure.Model.Entity;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.Identity.Domain.Model
{
    public class Organization : Aggregate
    {
        public string Name { get; set; }
        public Address Address { get; private set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }

        protected Organization()
        {

        }

        public void AddUser(ApplicationUser applicationUser)
        {
            if (Users == null) this.Users = new List<User>();

            this.Users.Add(new User(applicationUser, this));
        }

        public Organization(CreateOrganizationCommand command, ITimeService timeService)
        {
            this.Name = command.Name;
            this.Create = timeService.GetCurrent();
            this.Modyfication = timeService.GetCurrent();
            this.Address = new Address(command.Country, command.City, command.Street, command.Number);
            this.Company = new Company(command.CreateCompanyCommand, this.Address, this.Id);
        }
    }
}