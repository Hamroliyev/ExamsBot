// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;

namespace ExamsBot.Models.TelegramUsers.Exceptions
{
    public class TelegramUserValidationException : Exception
    {
        public TelegramUserValidationException(Exception innerException)
            : base(message: "Invalid input, contact support.", innerException) { }
    }
}

