// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;

namespace ExamsBot.Brokers.DateTimes
{
    public class DateTimeBroker : IDateTimeBroker
    {
        public DateTimeOffset GetCurrentDateTime() => DateTimeOffset.UtcNow;
    }
}
