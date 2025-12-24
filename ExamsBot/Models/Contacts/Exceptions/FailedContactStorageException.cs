// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using Xeptions;

namespace ExamsBot.Models.Contacts.Exceptions
{
    public class FailedContactStorageException : Xeption
    {
        public FailedContactStorageException(Exception innerException)
            : base(message: "Failed contact storage error occurred, contact support.", innerException)
        { }
    }
}
