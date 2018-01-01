using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore.Query.Internal;
using MyNote.Identity.Domain.Events.Address;
using MyNote.Identity.Domain.Events.Company;
using MyNote.Identity.Domain.Events.Organization;
using MyNote.Identity.Domain.Events.User;
using MyNote.Identity.Domain.Model;
using MyNote.Infrastructure.Model.Database;

namespace MyNote.Identity.Domain.Queries.Handlers
{
    public class OrganizationEventHandler : INotificationHandler<OrganizationCreated>,
                                            INotificationHandler<OrganizationUpdated>

    {
        private readonly IDataRepository<Organization> _organizationRepository;
        private readonly IDataRepository<User> _userRepository;

        public OrganizationEventHandler(IDataRepository<Organization> organizationRepository,
                                        IDataRepository<Address> addressRepository,
                                        IDataRepository<Company> companyRepository,
                                        IDataRepository<User> userRepository)
        {
            if (organizationRepository == null) throw new ArgumentNullException(nameof(organizationRepository));
            if (addressRepository == null) throw new ArgumentNullException(nameof(addressRepository));
            if (companyRepository == null) throw new ArgumentNullException(nameof(companyRepository));
            if (userRepository == null) throw new ArgumentNullException(nameof(userRepository));

            _organizationRepository = organizationRepository;
            _userRepository = userRepository;
        }
        public Task Handle(OrganizationCreated notification, CancellationToken cancellationToken)
        {
            var organization = new Organization();
            organization.Apply(notification);
            _organizationRepository.Add(organization);
            _organizationRepository.Save();
            return Task.CompletedTask;
        }
        

        public Task Handle(OrganizationUpdated notification, CancellationToken cancellationToken)
        {
            Organization organization = _organizationRepository.GetById(notification.OrganizationId);


            organization.Apply(notification);
            _organizationRepository.Update(organization);
            _organizationRepository.Save();
            return Task.CompletedTask;
        }
    }
}