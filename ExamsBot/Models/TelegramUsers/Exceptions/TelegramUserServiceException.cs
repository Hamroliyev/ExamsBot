// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;

namespace ExamsBot.Models.TelegramUsers.Exceptions
{
    public class TelegramUserServiceException : Exception
    {
        public TelegramUserServiceException(Exception innerException)
            : base(message: "Service error occurred, contact support.", innerException) { }
    }
}

