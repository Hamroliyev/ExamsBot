// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;

namespace ExamsBot.Models.Users.Exceptions
{
    public class LockedUserException : Exception
    {
        public LockedUserException(Exception innerException)
            : base(message: "Locked user record exception, please try again later.", innerException) { }
    }
}
