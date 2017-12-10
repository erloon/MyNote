using System;

namespace MyNote.Infrastructure.Model.Time
{
    public class TimeService : ITimeService
    {
        public DateTime GetCurrent()
        {
            return DateTime.Now;
        }
    }
}