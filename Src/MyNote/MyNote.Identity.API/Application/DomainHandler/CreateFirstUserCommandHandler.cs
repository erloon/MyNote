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
using Remotion.Linq.Clauses;

namespace MyNote.Identity.API.Application.DomainHandler
{
    public class CreateFirstUserCommandHandler : BaseHandler, IRequestHandler<CreateFirstUserCommand, bool>
    {
        private readonly IDataRepository<Organization> _organizationRepository;
        private readonly IRegisterService _registerService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateFirstUserCommandHandler(IDataRepository<Organization> organizationRepository,
                                                 IRegisterService registerService,
                                                 UserManager<ApplicationUser> userManager,
                                                 MyIdentityDbContext context)
            : base(context)
        {
            if (organizationRepository == null) throw new ArgumentNullException(nameof(organizationRepository));
            if (registerService == null) throw new ArgumentNullException(nameof(registerService));
            if (userManager == null) throw new ArgumentNullException(nameof(userManager));

            _organizationRepository = organizationRepository;
            _registerService = registerService;
            _userManager = userManager;
        }
        private ApplicationUser CreateUser(CreateFirstUserCommand notification, Organization organization)
        {
            var appUser = _registerService.Register(notification.RegisterUserCommand, organization);
            if (!appUser.Result.Succeeded) throw new ApplicationException("Nie udało się utworzyć użytkownika");
            return _userManager.FindByEmailAsync(notification.RegisterUserCommand.Email).Result;
        }

        public async Task<bool> Handle(CreateFirstUserCommand request, CancellationToken cancellationToken)
        {

            try
            {
                Organization organization = new Organization(request.CreateOrganizationCommand);
                await _organizationRepository.AddAsync(organization);
                _organizationRepository.Save();
            }
            catch (Exception ex)
            {
              
                throw;
            }
           
            //var user = CreateUser(request, organization);
            //organization.AddUser(user);
            //_organizationRepository.Update(organization);
            // _organizationRepository.Save();

            return true;
        }
    }
}