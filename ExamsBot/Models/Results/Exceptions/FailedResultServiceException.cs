// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using Xeptions;

namespace ExamsBot.Models.Results.Exceptions
{
    public class FailedResultServiceException : Xeption
    {
        public FailedResultServiceException(Exception innerException)
            : base(message: "Failed result service error occurred, contact support.", innerException) { }
    }
}