using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyNote.Identity.Domain.Commands.Project;
using MyNote.Identity.Domain.Model;
using MyNote.Identity.Domain.Queries;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Exception;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.Identity.API.Application.DomainHandler
{
    public class ProjectHandler : IRequestHandler<CreateProjectCommand, Project>,
                                    IRequestHandler<UpdateProjectCommand, Project>,
                                    IRequestHandler<DeleteProjectCommand, bool>
    {
        private readonly IDomainEventsService _domainEventsService;
        private readonly IProjectQuery _projectQuery;
        private readonly ITimeService _timeService;

        public ProjectHandler(IDomainEventsService domainEventsService,
                                IProjectQuery projectQuery,
                                ITimeService timeService)
        {
            if (domainEventsService == null) throw new ArgumentNullException(nameof(domainEventsService));
            if (projectQuery == null) throw new ArgumentNullException(nameof(projectQuery));
            if (timeService == null) throw new ArgumentNullException(nameof(timeService));

            _domainEventsService = domainEventsService;
            _projectQuery = projectQuery;
            _timeService = timeService;
        }
        public Task<Project> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            Project project = new Project(request, _timeService, _domainEventsService);
            return Task.FromResult(project);
        }

        public async Task<Project> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectQuery.GetAsync(request.ProjectId, request.OrganizationId) 
                ?? throw new DomainException("Project not found", request.ProjectId);
            project.Update(request,_timeService,_domainEventsService);
            return await Task.FromResult(project); 
        }

        public async Task<bool> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectQuery.GetAsync(request.ProjectId, request.OrganizationId)
                          ?? throw new DomainException("Project not found", request.ProjectId);
            project.Delete(request,_domainEventsService);
            return await Task.FromResult(true);
        }
    }
}