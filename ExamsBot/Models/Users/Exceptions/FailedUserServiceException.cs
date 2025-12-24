// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using Xeptions;

namespace ExamsBot.Models.Users.Exceptions
{
    public class FailedUserServiceException : Xeption
    {
        public FailedUserServiceException(Exception innerException)
            : base(message: "Failed user service error occurred.", innerException)
        { }
    }
}
