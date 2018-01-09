using System;

namespace MyNote.Infrastructure.Model.Entity
{
    public class ConnectedNote : Entity
    {
        public Guid Note { get; protected set; }
        public Guid Connected { get; protected set; }
    }
}