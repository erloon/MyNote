using System;
using System.Collections.Generic;
using MyNote.Identity.Domain.Commands.Address;
using MyNote.Identity.Domain.Commands.Company;
using MyNote.Identity.Domain.Commands.Organization;
using MyNote.Identity.Domain.Commands.Project;
using MyNote.Identity.Domain.Commands.Resource;
using MyNote.Identity.Domain.Commands.User;
using MyNote.Identity.Domain.Events.Organization;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Entity;
using MyNote.Infrastructure.Model.Exception;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.Identity.Domain.Model
{
    public class Organization : Aggregate
    {
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
        public Organization(CreateOrganizationCommand command, ITimeService timeService, IDomainEventsService domainEventsService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (timeService == null) throw new ArgumentNullException(nameof(timeService));

            var @event = new OrganizationCreated(command, timeService);
            domainEventsService.Save(@event);
            Apply(@event);

        }

        public void Update(UpdateOrganizationCommand command, IDomainEventsService domainEventsService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (domainEventsService == null) throw new ArgumentNullException(nameof(domainEventsService));

            var @event = new OrganizationUpdated(command);
            domainEventsService.Save(@event);
            Apply(@event);
        }

        public void AddProject(CreateProjectCommand command, ITimeService timeService, IDomainEventsService domainEventsService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (timeService == null) throw new ArgumentNullException(nameof(timeService));

            if (this.Projects == null) this.Projects = new List<Project>();

            this.Projects.Add(new Project(command, timeService, domainEventsService));
        }

        public void AddUser(CreateUserCommand command, ITimeService timeService, ApplicationUser applicationUser, IDomainEventsService domainEventsService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (timeService == null) throw new ArgumentNullException(nameof(timeService));
            if (applicationUser == null) throw new ArgumentNullException(nameof(applicationUser));

            if (this.Users == null) this.Users = new List<User>();

            this.Users.Add(new User(command, applicationUser, this.Id, timeService, domainEventsService));
        }

        public void AddResource(CreateResourceCommand command, ITimeService timeService, IDomainEventsService domainEventsService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (timeService == null) throw new ArgumentNullException(nameof(timeService));

            if (this.Resources == null) this.Resources = new List<Resource>();

            this.Resources.Add(new Resource(command, timeService, domainEventsService));
        }

        public void Apply(OrganizationCreated @event)
        {
            if (@event == null) throw new ArgumentNullException(nameof(@event));

            this.Id = @event.OrganizationId;
            this.Name = @event.Name;
            AddAddress(@event);

            AddCompany(@event);

            this.Modification = @event.Modification;
            this.CreateBy = @event.CreateBy.Value;
            this.UpdateBy = @event.UpdateBy.Value;
            this.Create = @event.Create;
        }

        private void AddCompany(OrganizationCreated @event)
        {
            Company company = new Company();
            @event.Company.CreateBy = @event.CreateBy.Value;
            @event.Company.UpdateBy = @event.UpdateBy.Value;
            company.Apply(@event.Company);
            this.Company = company;
            this.CompanyId = CompanyId;
        }

        private void AddAddress(OrganizationCreated @event)
        {
            Address address = new Address();
            @event.Address.CreateBy = @event.CreateBy.Value;
            @event.Address.UpdateBy = @event.UpdateBy.Value;
            @event.Address.OrganizationId = @event.OrganizationId;
            address.Apply(@event.Address);
            this.Address = address;
            this.AddressId = address.Id;
        }

        public void Apply(OrganizationUpdated @event)
        {
            if (@event == null) throw new ArgumentNullException(nameof(@event));

            this.Name = @event.Name;
            this.AddressId = @event.AddressId;
            this.CompanyId = @event.CompanyId;
            this.Modification = @event.Modification;
            this.UpdateBy = @event.UpdateBy.Value;

        }



    }
}