// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using Xeptions;

namespace ExamsBot.Models.TelegramUsers.Exceptions
{
    public class NullTelegramUserException : Xeption
    {
        public NullTelegramUserException()
            : base(message: "The telegram user is null.")
        { }
    }
}

