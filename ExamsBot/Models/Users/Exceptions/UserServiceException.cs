// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;

namespace ExamsBot.Models.Users.Exceptions
{
    public class UserServiceException : Exception
    {
        public UserServiceException(Exception innerException)
            : base(message: "Service error occurred, contact support.", innerException) { }
    }
}
