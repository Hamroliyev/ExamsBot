// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;

namespace ExamsBot.Models.TelegramUsers.Exceptions
{
    public class LockedTelegramUserException : Exception
    {
        public LockedTelegramUserException(Exception innerException)
            : base(message: "Locked telegram user record exception, please try again later.", innerException) { }
    }
}

