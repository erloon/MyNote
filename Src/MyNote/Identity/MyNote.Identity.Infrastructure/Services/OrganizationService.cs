using System;
using MyNote.Identity.Domain.Model;
using MyNote.Identity.Domain.Model.Commands;
using MyNote.Identity.Domain.Model.DomainEvents;
using MyNote.Identity.Infrastructure.Services.Contracts;
using MyNote.Infrastructure.Model;
using MyNote.Infrastructure.Model.Time;
using MediatR;

namespace MyNote.Identity.Infrastructure.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IDataRepository<Organization> _organizationRepository;
        private readonly IMediator _mediator;
        private readonly ITimeService _timeService;

        public OrganizationService(IDataRepository<Organization> organizationRepository,
                                    IMediator mediator)
        {
            if (organizationRepository == null) throw new ArgumentNullException(nameof(organizationRepository));
            if (mediator == null) throw new ArgumentNullException(nameof(mediator));
            _organizationRepository = organizationRepository;
            _mediator = mediator;
        }
        public Organization Create(CreateOrganizationCommand command, ITimeService timeService)
        {
            Organization organization = new Organization(command, timeService);
            _organizationRepository.AddAsync(organization);
            _organizationRepository.Save();

            OrganizationCreated organizationCreated = new OrganizationCreated(organization,command,_timeService);
            _mediator.Publish(organizationCreated);

            return organization;
        }
    }
}