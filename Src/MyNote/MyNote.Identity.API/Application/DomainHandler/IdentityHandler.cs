using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MyNote.Identity.Domain.Commands.User;
using MyNote.Identity.Domain.Model;
using MyNote.Identity.Infrastructure.Services.Contracts;
using MyNote.Infrastructure.Model.Database;

namespace MyNote.Identity.API.Application.DomainHandler
{
    public class IdentityHandler
        : IRequestHandler<RegisterUserCommand, IdentityResult>

    {
        private readonly IRegisterService _registerService;
        private readonly IMediator _mediator;
        private readonly ILoginService _loginService;

        public IdentityHandler(IRegisterService registerService,
                            IMediator mediator,
                            IDataRepository<Organization> organizationRepository,
                            ILoginService loginService)
        {
            if (registerService == null) throw new ArgumentNullException(nameof(registerService));
            if (mediator == null) throw new ArgumentNullException(nameof(mediator));
            if (organizationRepository == null) throw new ArgumentNullException(nameof(organizationRepository));
            if (loginService == null) throw new ArgumentNullException(nameof(loginService));

            _registerService = registerService;
            _mediator = mediator;
            _loginService = loginService;
        }

        public async Task<IdentityResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            IdentityResult result = null;

            result = await _registerService.Register(request);

            return result;

        }

    }
}