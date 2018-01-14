using System;
using System.Threading.Tasks;
using MediatR;
using MyNote.Identity.Domain.Commands.Resource;
using MyNote.Identity.Domain.Events.Resource;
using MyNote.Identity.Domain.IntegrationEvents;
using MyNote.Identity.Domain.Model;
using MyNote.Infrastructure.Model.Database;
using MyNote.Infrastructure.Model.EventBusRabbitMQ;

namespace MyNote.Identity.API.Application
{
    public class NoteIntegrationEventHandler : IIntegrationEventHandler<NoteCreated>
    {
        private readonly IMediator _mediator;

        public NoteIntegrationEventHandler(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public Task Handle(NoteCreated @event)
        {
            CreateResourceCommand command = new CreateResourceCommand()
            {
                ContentId = @event.NoteId,
                CreateBy = @event.CreateBy,
                OrganizationId = @event.OrganizationId,
                OwnerId =@event.OwnerId,
                UpdateBy = @event.UpdateBy
            };

            return _mediator.Send(command);
        }
    }
}