// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;

namespace ExamsBot.Models.TelegramUsers.Exceptions
{
    public class AlreadyExistsTelegramUserException : Exception
    {
        public AlreadyExistsTelegramUserException(Exception innerException)
            : base(message: "Telegram user with the same id already exists.", innerException) { }
    }
}

