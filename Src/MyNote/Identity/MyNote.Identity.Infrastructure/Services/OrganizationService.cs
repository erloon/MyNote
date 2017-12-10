using System;
using MyNote.Identity.Domain.Model;
using MyNote.Identity.Domain.Model.Commands;
using MyNote.Identity.Infrastructure.Services.Contracts;
using MyNote.Infrastructure.Model;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.Identity.Infrastructure.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IDataRepository<Organization> _organizationRepository;
        private readonly ITimeService _timeService;

        public OrganizationService(IDataRepository<Organization> organizationRepository)
        {
            if (organizationRepository == null) throw new ArgumentNullException(nameof(organizationRepository));
            _organizationRepository = organizationRepository;
        }
        public Organization Create(CreateOrganizationCommand command, ITimeService timeService)
        {
            Organization organization = new Organization(command, timeService);
            _organizationRepository.AddAsync(organization);
            _organizationRepository.Save();
            return organization;
        }
    }
}