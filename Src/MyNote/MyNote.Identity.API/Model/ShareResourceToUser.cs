﻿using System;

namespace MyNote.Identity.API.Model
{
    public class ShareResourceToUser
    {
        public Guid OwnerId { get; set; }
        public Guid ResourceId { get; set; }
        public Guid UserId { get; set; }
    }
}