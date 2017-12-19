using System;
using System.Collections.Generic;
using MyNote.Identity.Domain.Commands.Address;
using MyNote.Identity.Domain.Commands.Company;
using MyNote.Identity.Domain.Commands.Organization;
using MyNote.Identity.Domain.Commands.Project;
using MyNote.Identity.Domain.Events.Address;
using MyNote.Identity.Domain.Events.Organization;
using MyNote.Infrastructure.Model.Entity;
using MyNote.Infrastructure.Model.Exception;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.Identity.Domain.Model
{
    public class Organization : Aggregate
    {
        public string Name { get; protected set; }
        public Address Address { get; protected set; }
        public Guid AddressId { get; protected set; }
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
            var @event = new OrganizationCreated(command);
            Append(@event);
            Apply(@event);

            AddAddress(new CreateAddressCommand(command.Country, command.City, command.Street, command.Number, this.Id), timeService);
            AddCompany(command.CreateCompanyCommand);

        }

        public void Apply(OrganizationCreated @event)
        {
            this.Id = @event.OrganizationId;
            this.Name = @event.Name;
        }

        public void AddAddress(CreateAddressCommand command, ITimeService timeService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (this.Address != null) throw new DomainException("Organization already have address set", this.Id);
            {
                var @event = new AddresCreated(command);

                Append(@event);
                Apply(@event, timeService);
            }
        }

        public void Apply(AddresCreated @event, ITimeService timeService)
        {
            this.Address = new Address(@event, timeService);
        }

        public void AddCompany(CreateCompanyCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            if (this.Company != null) throw new DomainException("Organization already have company set", this.Id);

            this.Company = new Company(command, this.AddressId, this.Id);
        }

        public void AddProject(CreateProjectCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            if (this.Projects == null) this.Projects = new List<Project>();

            this.Projects.Add(new Project(command));
        }
    }
}