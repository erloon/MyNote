using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyNote.Identity.Domain.Commands.User;
using MyNote.Identity.Domain.Model;
using MyNote.Identity.Domain.Queries;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Exception;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.Identity.API.Application.DomainHandler
{
    public class UserHandler : IRequestHandler<CreateUserCommand, User>,
                                IRequestHandler<UpdateUserCommand, User>,
                                IRequestHandler<DeleteUserCommand, bool>,
                                IRequestHandler<AddUserToTeamCommand, User>,
                                IRequestHandler<RemoveUserFromTeamCommand, User>,
                                IRequestHandler<AddUserToProjectCommand, User>,
                                IRequestHandler<RemoveUserFromProjectCommand, User>
    {
        private readonly IDomainEventsService _domainEventsService;
        private readonly IUserQuery _userQuery;
        private readonly ITimeService _timeService;

        public UserHandler(IDomainEventsService domainEventsService,
                            IUserQuery userQuery,
                            ITimeService timeService)
        {
            if (domainEventsService == null) throw new ArgumentNullException(nameof(domainEventsService));
            if (userQuery == null) throw new ArgumentNullException(nameof(userQuery));
            if (timeService == null) throw new ArgumentNullException(nameof(timeService));

            _domainEventsService = domainEventsService;
            _userQuery = userQuery;
            _timeService = timeService;
        }
        public async Task<User> Handle(RemoveUserFromProjectCommand request, CancellationToken cancellationToken)
        {
            var user = await _userQuery.GetAsync(request.UserId, request.OrganizationId)
                       ?? throw new DomainException("User not found", request.UserId);

            user.RemoveFromProject(request, _domainEventsService);
            return await Task.FromResult(user);
        }

        public async Task<User> Handle(AddUserToProjectCommand request, CancellationToken cancellationToken)
        {
            var user = await _userQuery.GetAsync(request.UserId, request.OrganizationId)
                       ?? throw new DomainException("User not found", request.UserId);

            user.AddToProject(request, _domainEventsService);
            return await Task.FromResult(user);
        }

        public async Task<User> Handle(RemoveUserFromTeamCommand request, CancellationToken cancellationToken)
        {
            var user = await _userQuery.GetAsync(request.UserId, request.OrganizationId);
            user.RemoveFromTeam(request, _domainEventsService);
            return await Task.FromResult(user);
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User user = new User(request, request.ApplicationUser, request.OrganizationId, _timeService, _domainEventsService);
            return await Task.FromResult(user);
        }

        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userQuery.GetAsync(request.UserId, request.OrganizationId) 
                ?? throw new DomainException("User not found", request.UserId);
            user.Update(request,_timeService,_domainEventsService);
            return await Task.FromResult(user);
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userQuery.GetAsync(request.UserId, request.OrganizationId)
                       ?? throw new DomainException("User not found", request.UserId);
            user.Delete(request,_domainEventsService);
            return await Task.FromResult(true);
        }

        public async Task<User> Handle(AddUserToTeamCommand request, CancellationToken cancellationToken)
        {
            var user = await _userQuery.GetAsync(request.UserId, request.OrganizationId);
            user.AddToTeam(request, _domainEventsService);
            return await Task.FromResult(user);
        }
    }
}