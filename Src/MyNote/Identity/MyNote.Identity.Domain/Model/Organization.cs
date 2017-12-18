using System;
using System.Collections.Generic;
using MyNote.Identity.Domain.Commands.Address;
using MyNote.Identity.Domain.Commands.Company;
using MyNote.Identity.Domain.Commands.Organization;
using MyNote.Infrastructure.Model.Entity;
using MyNote.Infrastructure.Model.Exceptions;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.Identity.Domain.Model
{
    public class Organization : Aggregate
    {
        public string Name { get; protected set; }
        public Address Address { get; protected set; }
        public Guid CompanyId { get; protected set; }
        public Company Company { get; protected set; }
        public virtual ICollection<Project> Projects { get; protected set; }
        public virtual ICollection<User> Users { get; protected set; }
        public virtual ICollection<Resource> Resources { get; protected set; }

        public Organization() { }

        public void CreateUser(ITimeService timeService, ApplicationUser applicationUser)
        {
            var now = timeService.GetCurrent();
            User user = new User(applicationUser, this);
            user.Create = now;
            user.Modyfication = now;

        }

        public Organization(CreateOrganizationCommand command, ITimeService timeService)
        {
            var now = timeService.GetCurrent();
            this.Id = Guid.NewGuid();
            this.Name = command.Name;
            this.Create = now;
            this.Modyfication = now;
           
        }

        public void AddAddress(CreateAddressCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (this.Address !=null) throw new DomainException("Organization already have address set",this.Id);
            {
                
            }
        }

        public void AddCompany(CreateCompanyCommand command, Guid addressId)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            if (this.Company != null) throw new DomainException("Organization already have company set", this.Id);

            this.Company = new Company(command, addressId, this.Id);
        }
    }
}