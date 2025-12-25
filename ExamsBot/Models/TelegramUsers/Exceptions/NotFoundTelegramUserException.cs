// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using Xeptions;

namespace ExamsBot.Models.TelegramUsers.Exceptions
{
    public class NotFoundTelegramUserException : Xeption
    {
        public NotFoundTelegramUserException(Guid telegramUserId)
            : base(message: $"Couldn't find telegram user with id: {telegramUserId}.")
        { }
    }
}

