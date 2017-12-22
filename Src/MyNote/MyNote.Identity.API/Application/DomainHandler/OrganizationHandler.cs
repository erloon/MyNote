using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MyNote.Identity.Domain.Commands.Address;
using MyNote.Identity.Domain.Commands.Company;
using MyNote.Identity.Domain.Commands.Organization;
using MyNote.Identity.Domain.Commands.Resource;
using MyNote.Identity.Domain.Commands.User;
using MyNote.Identity.Domain.Model;
using MyNote.Identity.Domain.Queries;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Exception;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.Identity.API.Application.DomainHandler
{
    public class OrganizationHandler
        : IRequestHandler<CreateOrganizationCommand, Organization>,
          IRequestHandler<CreateAddressCommand, Organization>,
          IRequestHandler<CreateCompanyCommand, Organization>,
          IRequestHandler<CreateUserCommand, User>
    {
        private readonly ITimeService _timeService;
        private readonly IOrganizationQuery _organizationQuery;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IDomainEventsService _domainEventsService;

        public OrganizationHandler(ITimeService timeService,
                                    IOrganizationQuery organizationQuery,
                                    UserManager<ApplicationUser> userManager,
                                    IDomainEventsService domainEventsService)
        {
            if (timeService == null) throw new ArgumentNullException(nameof(timeService));
            if (organizationQuery == null) throw new ArgumentNullException(nameof(organizationQuery));
            if (userManager == null) throw new ArgumentNullException(nameof(userManager));
            if (domainEventsService == null) throw new ArgumentNullException(nameof(domainEventsService));

            _timeService = timeService;
            _organizationQuery = organizationQuery;
            _userManager = userManager;
            _domainEventsService = domainEventsService;
        }

        public async Task<Organization> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
        {
            Organization organization = new Organization(request, _timeService, _domainEventsService);
            return await Task.FromResult(organization);
        }

        public async Task<Organization> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            Organization organization = await _organizationQuery.GetAsync(request.OrganizationId) ??
                                        throw new DomainException("Organization not exists", request.OrganizationId);

            organization.AddAddress(request, _timeService, _domainEventsService);
            return organization;
        }

        public async Task<Organization> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            Organization organization = await _organizationQuery.GetAsync(request.OrganizationId) ??
                                        throw new DomainException("Organization not exists", request.OrganizationId);
            organization.AddCompany(request, _timeService, _domainEventsService);
            return organization;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            Organization organization = await _organizationQuery.GetAsync(request.OrganizationId) ??
                                        throw new DomainException("Organization not exists", request.OrganizationId);
            ApplicationUser applicationUser =
                _userManager.Users.FirstOrDefault(x => x.Email.Equals(request.UserName)) ??
                throw new DomainException("Can't find user in organization", request.OrganizationId);

            organization.AddUser(request, _timeService, applicationUser, _domainEventsService);

            var user = organization.Users.FirstOrDefault(x => x.ApplicationUser.Id.Equals(applicationUser.Id));
            return user;
        }
    }
}