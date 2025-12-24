// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;

namespace ExamsBot.Models.Contacts.Exceptions
{
    public class NotFoundContactException : Exception
    {
        public NotFoundContactException(Guid contactId)
            : base(message: $"Couldn't find contact with id: {contactId}.") { }
    }
}
