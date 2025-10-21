// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;

namespace ExamsBot.Models.AssignmentAttachments.Exceptions
{
    public class AssignmentAttachmentServiceException : Exception
    {
        public AssignmentAttachmentServiceException(Exception innerException)
            : base(message: "Service error occurred, contact support.", innerException) { }
    }
}
