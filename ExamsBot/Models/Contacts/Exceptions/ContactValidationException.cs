// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;

namespace ExamsBot.Models.Contacts.Exceptions
{
    public class ContactValidationException : Exception
    {
        public ContactValidationException(Exception innerException)
            : base(message: "Invalid input, contact support.", innerException) { }
    }
}
