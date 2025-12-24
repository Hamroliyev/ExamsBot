// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;

namespace ExamsBot.Models.Users.Exceptions
{
    public class UserValidationException : Exception
    {
        public UserValidationException(Exception innerException)
            : base(message: "Invalid input, contact support.", innerException) { }
    }
}
