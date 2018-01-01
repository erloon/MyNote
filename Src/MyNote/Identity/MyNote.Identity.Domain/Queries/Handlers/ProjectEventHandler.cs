using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyNote.Identity.Domain.Events.Project;
using MyNote.Identity.Domain.Events.Team;
using MyNote.Identity.Domain.Model;
using MyNote.Infrastructure.Model.Database;
using MyNote.Infrastructure.Model.Exception;

namespace MyNote.Identity.Domain.Queries.Handlers
{
    public class ProjectEventHandler : INotificationHandler<ProjectCreated>,
                                        INotificationHandler<ProjectUpdated>,
                                        INotificationHandler<ProjectDeleted>
    {
        private readonly IDataRepository<Project> _projectRepository;
        private readonly IProjectQuery _projectQuery;

        public ProjectEventHandler(IDataRepository<Project> projectRepository,
                                    IProjectQuery projectQuery)
        {
            if (projectRepository == null) throw new ArgumentNullException(nameof(projectRepository));
            if (projectQuery == null) throw new ArgumentNullException(nameof(projectQuery));
            _projectRepository = projectRepository;
            _projectQuery = projectQuery;
        }
        public Task Handle(ProjectCreated notification, CancellationToken cancellationToken)
        {
            Project project = new Project();
            project.Apply(notification);
            _projectRepository.Add(project);
            _projectRepository.Save();
            return Task.CompletedTask;
        }

        public  Task Handle(ProjectUpdated notification, CancellationToken cancellationToken)
        {
            var project =  _projectQuery.GetAsync(notification.ProjectId, notification.OrganizationId).Result
                          ?? throw new DomainException("Project not found", notification.ProjectId);

            project.Apply(notification);
            _projectRepository.Update(project);
            _projectRepository.Save();
            return Task.CompletedTask;
        }

        public Task Handle(ProjectDeleted notification, CancellationToken cancellationToken)
        {
            var project = _projectQuery.GetAsync(notification.ProjectId, notification.OrganizationId).Result 
                ?? throw new DomainException("Project not found", notification.ProjectId);
            _projectRepository.Delete(project);
            _projectRepository.Save();
            return Task.CompletedTask;
        }
    }
}