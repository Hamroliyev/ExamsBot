// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using Xeptions;

namespace ExamsBot.Models.TelegramUsers.Exceptions
{
    public class FailedTelegramUserServiceException : Xeption
    {
        public FailedTelegramUserServiceException(Exception innerException)
            : base(message: "Failed telegram user service error occurred.", innerException)
        { }
    }
}

