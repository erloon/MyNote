﻿using System;
using MyNote.Identity.Domain.Commands.Resource;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Events.Resource
{
    public class ResourceFromTeamRemoved : DomainEvent
    {
        public string OwnerId { get; set; }
        public Guid ResourceId { get; set; }
        public Guid TeamId { get; set; }
        public Guid OrganizationId { get; set; }

        public ResourceFromTeamRemoved(RemoveResourceFromTeamCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            this.OrganizationId = command.OrganizationId;
            this.OwnerId = command.OwnerId.ToString();
            this.ResourceId = command.ResourceId;
            this.TeamId = command.TeamId;
        }
    }
}