// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;

namespace ExamsBot.Models.Users.Exceptions
{
    public class AlreadyExistsUserException : Exception
    {
        public AlreadyExistsUserException(Exception innerException)
            : base(message: "User with the same id already exists.", innerException) { }
    }
}
