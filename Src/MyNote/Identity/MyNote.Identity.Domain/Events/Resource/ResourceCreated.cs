using System;
using MyNote.Identity.Domain.Commands.Resource;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.Identity.Domain.Events.Resource
{
    public class ResourceCreated : DomainEvent
    {
        public Guid ResourceId { get; set; }
        public string OwnerId { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid? ContentId { get; set; }
        public DateTime Create { get; set; }

        public ResourceCreated(CreateResourceCommand command, ITimeService timeService)
        {
            this.OrganizationId = command.OrganizationId;
            this.Create = timeService.GetCurrent();
            this.OwnerId = command.OwnerId;
            this.ContentId = command.ContentId;
            this.ResourceId = Guid.NewGuid();
        }
    }
}