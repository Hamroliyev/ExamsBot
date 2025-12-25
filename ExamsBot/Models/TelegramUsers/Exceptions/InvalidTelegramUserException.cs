// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;

namespace ExamsBot.Models.TelegramUsers.Exceptions
{
    public class InvalidTelegramUserException : Exception
    {
        public InvalidTelegramUserException(string parameterName, object parameterValue)
            : base(message: $"Invalid telegram user, " +
                  $"parameter name: {parameterName}, " +
                  $"parameter value: {parameterValue}.")
        { }
    }
}

