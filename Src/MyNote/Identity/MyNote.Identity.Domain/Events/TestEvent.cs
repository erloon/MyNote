using System;
using RawRabbit.Context;

namespace MyNote.Identity.Domain.Events
{
    public class TestEvent : IMessageContext
    {
        public string Wiadomosc { get; set; }
        public Guid GlobalRequestId { get; set; }
    }
}