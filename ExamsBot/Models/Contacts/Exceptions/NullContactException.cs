// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;

namespace ExamsBot.Models.Contacts.Exceptions
{
    public class NullContactException : Exception
    {
        public NullContactException() : base(message: "The contact is null.") { }
    }
}
