﻿using MyNote.Identity.Domain.Events.User;
using System;

namespace MyNote.Identity.Domain.Model
{
    public class UserProject
    {
        public Guid UserId { get; protected set; }
        public User User { get; protected set; }
        public Guid ProjectId { get; protected set; }
        public Project Project { get; protected set; }

        public UserProject(UserToProjectAdded @event)
        {
            this.ProjectId = @event.ProjectId;
            this.UserId = @event.UserId;
        }
    }
}