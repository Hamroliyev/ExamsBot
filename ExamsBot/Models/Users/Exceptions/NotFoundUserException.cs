// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;

namespace ExamsBot.Models.Users.Exceptions
{
    public class NotFoundUserException : Exception
    {
        public NotFoundUserException(Guid userId)
            : base(message: $"Couldn't find user with id: {userId}.") { }
    }
}
