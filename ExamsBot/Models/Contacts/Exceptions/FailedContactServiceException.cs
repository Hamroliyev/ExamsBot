// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using Xeptions;

namespace ExamsBot.Models.Contacts.Exceptions
{
    public class FailedContactServiceException : Xeption
    {
        public FailedContactServiceException(Exception innerException)
            : base(message: "Failed contact service error occured, contact support",
                 innerException)
        { }
    }
}
