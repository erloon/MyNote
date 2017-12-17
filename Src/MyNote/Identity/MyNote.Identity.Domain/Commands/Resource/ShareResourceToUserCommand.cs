﻿using System;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Identity.Domain.Commands.Resource
{
    public class ShareResourceToUserCommand : BaseCommand
    {
        public Guid OwnerId { get; set; }
        public Guid ResourceId { get; set; }
        public Guid UserId { get; set; }
    }
}