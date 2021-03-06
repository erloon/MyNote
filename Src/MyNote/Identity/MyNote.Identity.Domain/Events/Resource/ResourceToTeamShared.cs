﻿using System;
using MyNote.Identity.Domain.Commands.Resource;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Events.Resource
{
    public class ResourceToTeamShared : DomainEvent
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public Guid ResourceId { get; set; }
        public Guid TeamId { get; set; }
        public Guid OrganizationId { get; set; }

        public ResourceToTeamShared(ShareResourceToTeamCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            this.OrganizationId = command.OrganizationId;
            this.Id = Guid.NewGuid();
            this.OwnerId = command.OwnerId;
            this.ResourceId = command.ResourceId;
            this.TeamId = command.TeamId;
        }
    }
}