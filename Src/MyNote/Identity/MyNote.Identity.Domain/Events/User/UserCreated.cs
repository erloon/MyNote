﻿using System;
using Baseline.Reflection;
using Marten.Events;
using Marten.Events.Projections;
using MediatR;
using MyNote.Identity.Domain.Commands.User;
using MyNote.Identity.Domain.Model;
using MyNote.Infrastructure.Model.Domain;
using MyNote.Infrastructure.Model.Time;

namespace MyNote.Identity.Domain.Events.User
{
    public class UserCreated : DomainEvent, INotification
    {
        public Guid UserId { get; set; }
        public bool IsAdministrator { get; set; }
        public string UserName { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid CreateBy { get; set; }
        public Guid UpdateBy { get; set; }
        public DateTime Create { get; set; }
        public DateTime Modification { get; set; }

        public UserCreated(CreateUserCommand command, ApplicationUser applicationUser, Guid organizationId,
            ITimeService timeService)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (applicationUser == null) throw new ArgumentNullException(nameof(applicationUser));
            if (timeService == null) throw new ArgumentNullException(nameof(timeService));

            this.UserId = Guid.Parse(applicationUser.Id);
            this.IsAdministrator = command.IsAdministrator;
            this.UserName = applicationUser.UserName;
            this.ApplicationUser = applicationUser;
            this.OrganizationId = organizationId;
            this.Create = timeService.GetCurrent();
            this.CreateBy = command.CreateBy;
            this.UpdateBy = command.UpdateBy;
            this.Create = timeService.GetCurrent();
            this.Modification = timeService.GetCurrent();
        }
    }
}