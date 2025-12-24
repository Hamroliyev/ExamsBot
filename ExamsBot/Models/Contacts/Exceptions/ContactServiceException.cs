// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;

namespace ExamsBot.Models.Contacts.Exceptions
{
    public class ContactServiceException : Exception
    {
        public ContactServiceException(Exception innerException)
            : base(message: "Service error occurred, contact support.", innerException) { }
    }
}
