﻿using System;
using MyNote.Identity.Domain.Commands.User;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.Identity.Domain.Events.User
{
    public class UserUpdated : DomainEvent
    {
        public Guid UserId { get; set; }
        public Guid OrganizationId { get; set; }
        public string Name { get; set; }
        public Model.ApplicationUser ApplicationUser { get; set; }
        public DateTime Modification { get; set; }

        public UserUpdated(UpdateUserCommand command, ITimeService timeService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (timeService == null) throw new ArgumentNullException(nameof(timeService));

            this.UserId = command.UserId;
            this.OrganizationId = command.OrganizationId;
            this.Name = command.Name;
            this.ApplicationUser = command.ApplicationUser;
            this.Modification = timeService.GetCurrent();
        }
    }
}