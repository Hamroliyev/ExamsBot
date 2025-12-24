// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;

namespace ExamsBot.Models.Contacts.Exceptions
{
    public class AlreadyExistsContactException : Exception
    {
        public AlreadyExistsContactException(Exception innerException)
            : base(message: "Contact with the same id already exists.", innerException) { }
    }
}
