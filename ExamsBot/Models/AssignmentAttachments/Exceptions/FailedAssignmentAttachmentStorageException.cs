// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using Xeptions;

namespace ExamsBot.Models.AssignmentAttachments.Exceptions
{
    public class FailedAssignmentAttachmentStorageException : Xeption
    {
        public FailedAssignmentAttachmentStorageException(Exception innerException)
            : base(message: "Failed assignment attachment storage error occurred, contact support.", innerException)
        { }
    }
}
