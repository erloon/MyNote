using System;

namespace MyNote.Infrastructure.Model.Time
{
    public interface ITimeService
    {
        DateTime GetCurrent();
    }
}