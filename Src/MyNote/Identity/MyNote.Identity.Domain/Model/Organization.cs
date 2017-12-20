using System;
using System.Collections.Generic;
using MyNote.Identity.Domain.Commands.Address;
using MyNote.Identity.Domain.Commands.Company;
using MyNote.Identity.Domain.Commands.Organization;
using MyNote.Identity.Domain.Commands.Project;
using MyNote.Identity.Domain.Commands.Resource;
using MyNote.Identity.Domain.Commands.User;
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

        public Organization(CreateOrganizationCommand command, ITimeService timeService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (timeService == null) throw new ArgumentNullException(nameof(timeService));

            var @event = new OrganizationCreated(command);
            Append(@event);
            Apply(@event);

            AddAddress(new CreateAddressCommand(command.Country, command.City, command.Street, command.Number, this.Id), timeService);
            AddCompany(command.CreateCompanyCommand);
        }

        public void Apply(OrganizationCreated @event)
        {
            if (@event == null) throw new ArgumentNullException(nameof(@event));

            this.Id = @event.OrganizationId;
            this.Name = @event.Name;
        }

        public void AddAddress(CreateAddressCommand command, ITimeService timeService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (timeService == null) throw new ArgumentNullException(nameof(timeService));

            if (this.Address != null) throw new DomainException("Organization already have address set", this.Id);

            this.Address = new Address(command, timeService);
        }

        public void AddCompany(CreateCompanyCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            if (this.Company != null) throw new DomainException("Organization already have company set", this.Id);

            this.Company = new Company(command);
        }

        public void AddProject(CreateProjectCommand command, ITimeService timeService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (timeService == null) throw new ArgumentNullException(nameof(timeService));

            if (this.Projects == null) this.Projects = new List<Project>();

            this.Projects.Add(new Project(command, timeService));
        }

        public void AddUser(CreateUserCommand command, ITimeService timeService, ApplicationUser applicationUser)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (timeService == null) throw new ArgumentNullException(nameof(timeService));
            if (applicationUser == null) throw new ArgumentNullException(nameof(applicationUser));

            var now = timeService.GetCurrent();
            User user = new User(applicationUser, this);
            user.Create = now;
            user.Modification = now;
        }

        public void AddResource(CreateResourceCommand command, ITimeService timeService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (timeService == null) throw new ArgumentNullException(nameof(timeService));

            if (this.Resources == null) this.Resources = new List<Resource>();

            this.Resources.Add(new Resource(command, timeService));
        }


    }
}