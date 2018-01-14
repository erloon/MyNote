using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Notes.Domain.Events;



namespace MyNote.Notes.API.Integration
{
    public class NoteIntegrations : INotificationHandler<NoteCreated>,
                                    INotificationHandler<NoteDeleted>,
                                    INotificationHandler<NoteUpdated>
    {
 


        public NoteIntegrations()
        {
        }
        public Task Handle(NoteCreated notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(NoteDeleted notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task Handle(NoteUpdated notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}