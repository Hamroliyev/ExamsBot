// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using Xeptions;

namespace ExamsBot.Models.Contacts.Exceptions
{
    public class ContactDependencyException : Xeption
    {
        public ContactDependencyException(Exception innerException)
            : base(message: "Service dependency error occurred, contact support.", innerException) { }
    }
}
