// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using Xeptions;

namespace ExamsBot.Models.Results.Exceptions
{
    public class FailedResultStorageException : Xeption
    {
        public FailedResultStorageException(Exception innerException)
            : base(message: "Failed result storage error occurred, contact support.", innerException) { }
    }
}