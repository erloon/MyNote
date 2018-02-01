using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyNote.Identity.Domain.Events.Organization;
using MyNote.Identity.Domain.Model;
using MyNote.Infrastructure.Model.Database;
using MyNote.Infrastructure.Model.Exception;

namespace MyNote.Identity.Domain.Handlers
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
            Organization organization = _organizationRepository.GetById(notification.OrganizationId)
                                                                        ?? throw new DomainException("Nie znaleziono organizacji", notification.OrganizationId);

            organization.Apply(notification);
            _organizationRepository.Update(organization);
            _organizationRepository.Save();
            return Task.CompletedTask;
        }
    }
}