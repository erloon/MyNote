using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyNote.Identity.Domain.Commands.Resource;
using MyNote.Identity.Domain.Model;
using MyNote.Identity.Domain.Queries;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Exception;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.Identity.API.Application.DomainHandler
{
    public class ResourceHandler : IRequestHandler<ShareResourceToProjectCommand, bool>,
                                    IRequestHandler<ShareResourceToTeamCommand, bool>,
                                    IRequestHandler<ShareResourceToUserCommand, bool>,
                                    IRequestHandler<RemoveResourceFromTeamCommand, bool>,
                                    IRequestHandler<RemoveResourceFromProjectCommand, bool>,
                                    IRequestHandler<RemoveResourceFromUserCommand, bool>
    {
        private readonly IDomainEventsService _domainEventsService;
        private readonly IResourceQuery _resourceQuery;
        private readonly ITimeService _timeService;

        public ResourceHandler(IDomainEventsService domainEventsService,
                                IResourceQuery resourceQuery,
                                ITimeService timeService)
        {
            if (domainEventsService == null) throw new ArgumentNullException(nameof(domainEventsService));
            if (resourceQuery == null) throw new ArgumentNullException(nameof(resourceQuery));
            if (timeService == null) throw new ArgumentNullException(nameof(timeService));

            _domainEventsService = domainEventsService;
            _resourceQuery = resourceQuery;
            _timeService = timeService;
        }
        public async Task<bool> Handle(RemoveResourceFromUserCommand request, CancellationToken cancellationToken)
        {
            var resource = await _resourceQuery.GetAsync(request.ResourceId, request.OrganizationId)
                           ?? throw new DomainException("Resource not found", request.ResourceId); ;
            resource.RemoveUser(request, _domainEventsService);
            return await Task.FromResult(true);
        }

        public async Task<bool> Handle(RemoveResourceFromProjectCommand request, CancellationToken cancellationToken)
        {
            var resource = await _resourceQuery.GetAsync(request.ResourceId, request.OrganizationId)
                           ?? throw new DomainException("Resource not found", request.ResourceId); ;
            resource.RemoveProject(request, _domainEventsService);
            return await Task.FromResult(true);
        }

        public async Task<bool> Handle(RemoveResourceFromTeamCommand request, CancellationToken cancellationToken)
        {
            var resource = await _resourceQuery.GetAsync(request.ResourceId, request.OrganizationId)
                           ?? throw new DomainException("Resource not found", request.ResourceId); ;
            resource.RemoveTeam(request, _domainEventsService);
            return await Task.FromResult(true);
        }

        public async Task<bool> Handle(ShareResourceToUserCommand request, CancellationToken cancellationToken)
        {
            var resource = await _resourceQuery.GetAsync(request.ResourceId, request.OrganizationId)
                           ?? throw new DomainException("Resource not found", request.ResourceId); ;
            resource.AddUser(request, _domainEventsService);
            return await Task.FromResult(true);
        }

        public async Task<bool> Handle(ShareResourceToTeamCommand request, CancellationToken cancellationToken)
        {
            Resource resource = await _resourceQuery.GetAsync(request.ResourceId, request.OrganizationId)
                          ?? throw new DomainException("Resource not found", request.ResourceId);

            resource.AddTeam(request, _domainEventsService);
            return await Task.FromResult(true);
        }

        public async Task<bool> Handle(ShareResourceToProjectCommand request, CancellationToken cancellationToken)
        {
            Resource resource = await _resourceQuery.GetAsync(request.ResourceId, request.OrganizationId)
                       ?? throw new DomainException("Resource not found", request.ResourceId);
            resource.AddProject(request, _domainEventsService);
            return await Task.FromResult(true);
        }
    }
}