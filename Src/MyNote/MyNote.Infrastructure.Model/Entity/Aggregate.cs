using System;
using System.Collections.Generic;
using MyNote.Infrastructure.Model.Domain;

namespace MyNote.Infrastructure.Model.Entity
{
    public abstract class Aggregate : BaseEntity
    {
        public byte[] Timestamp { get; set; }
    }
}