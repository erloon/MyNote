﻿using System;
using MyNote.Identity.Domain.Commands.User;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Events.User
{
    public class UserToTeamAdded : DomainEvent
    {
        public Guid UserTeamId { get; set; }
        public Guid UserId { get; set; }
        public Guid TeamId { get; set; }
        public Guid OrganizationId { get; set; }
        public UserToTeamAdded(AddUserToTeamCommand command)
        {
            this.UserTeamId = Guid.NewGuid();
            this.TeamId = command.TeamId;
            this.UserId = command.UserId;
            this.OrganizationId = command.OrganizationId;
        }

        
    }
}