// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using Xeptions;

namespace ExamsBot.Models.TelegramUsers.Exceptions
{
    public class FailedTelegramUserStorageException : Xeption
    {
        public FailedTelegramUserStorageException(Exception innerException)
            : base(message: "Failed telegram user storage error occurred, contact support.",
                  innerException)
        { }
    }
}

