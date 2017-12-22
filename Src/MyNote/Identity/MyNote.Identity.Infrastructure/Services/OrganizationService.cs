using System;
using MyNote.Identity.Domain.Model;
using MyNote.Identity.Infrastructure.Services.Contracts;
using MyNote.Infrastructure.Model;
using MyNote.Infrastructure.Model.Time;
using MediatR;
using MyNote.Identity.Domain.Commands.Organization;
using MyNote.Infrastructure.Model.Database;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Infrastructure.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IDataRepository<Organization> _organizationRepository;
        private readonly IMediator _mediator;
        private readonly IDomainEventsService _domainEventsService;
        private readonly ITimeService _timeService;

        public OrganizationService(IDataRepository<Organization> organizationRepository,
                                    IMediator mediator,
                                    IDomainEventsService domainEventsService)
        {
            if (organizationRepository == null) throw new ArgumentNullException(nameof(organizationRepository));
            if (mediator == null) throw new ArgumentNullException(nameof(mediator));
            if (domainEventsService == null) throw new ArgumentNullException(nameof(domainEventsService));

            _organizationRepository = organizationRepository;
            _mediator = mediator;
            _domainEventsService = domainEventsService;
        }
        public Organization Create(CreateOrganizationCommand command, ITimeService timeService)
        {
            Organization organization = new Organization(command, timeService, _domainEventsService);
            _organizationRepository.AddAsync(organization);
            _organizationRepository.Save();

            return organization;
        }
    }
}