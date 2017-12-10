using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MyNote.Identity.Domain.Model;
using MyNote.Identity.Domain.Model.Commands;
using MyNote.Identity.Domain.Model.Commands.User;
using MyNote.Identity.Domain.Model.DomainEvents;
using MyNote.Identity.Infrastructure;
using MyNote.Infrastructure.Model;
using MyNote.Identity.Infrastructure.Services.Contracts;
using MyNote.Infrastructure.Model.Time;
using Remotion.Linq.Clauses;

namespace MyNote.Identity.API.Application.DomainHandler
{
    public class CreateFirstUserCommandHandler : BaseHandler, IRequestHandler<CreateFirstUserCommand, bool>
    {
        private readonly IDataRepository<Organization> _organizationRepository;
        private readonly IRegisterService _registerService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITimeService _timeService;
        private readonly IOrganizationService _organizationService;

        public CreateFirstUserCommandHandler(
                                             IRegisterService registerService,
                                             UserManager<ApplicationUser> userManager,
                                             ITimeService timeService,
                                             IOrganizationService organizationService)
        {
            if (registerService == null) throw new ArgumentNullException(nameof(registerService));
            if (userManager == null) throw new ArgumentNullException(nameof(userManager));
            if (timeService == null) throw new ArgumentNullException(nameof(timeService));
            if (organizationService == null) throw new ArgumentNullException(nameof(organizationService));

            _registerService = registerService;
            _userManager = userManager;
            _timeService = timeService;
            _organizationService = organizationService;
        }
        private void CreateUser(CreateFirstUserCommand notification, Organization organization)
        {
            var identityResult = _registerService.Register(notification.RegisterUserCommand, organization);
            if (identityResult == null) throw new ApplicationException("Nie udało się utworzyć użytkownika");
            _userManager.FindByNameAsync(notification.RegisterUserCommand.Email);

        }


        public async Task<bool> Handle(CreateFirstUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var organization = _organizationService.Create(request.CreateOrganizationCommand, _timeService);
                CreateUser(request, organization);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}