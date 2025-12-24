// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;

namespace ExamsBot.Models.Contacts.Exceptions
{
    public class LockedContactException : Exception
    {
        public LockedContactException(Exception innerException)
            : base(message: "Locked contact record exception, please try again later.", innerException) { }
    }
}
