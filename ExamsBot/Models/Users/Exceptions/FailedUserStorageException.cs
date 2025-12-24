// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using Xeptions;

namespace ExamsBot.Models.Users.Exceptions
{
    public class FailedUserStorageException : Xeption
    {
        public FailedUserStorageException(Exception innerException)
            : base(message: "Failed user storage error occurred, contact support.",
                  innerException)
        { }
    }
}
