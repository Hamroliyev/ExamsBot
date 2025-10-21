// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using Xeptions;

namespace ExamsBot.Models.AssignmentAttachments.Exceptions
{
    public class FailedAssignmentAttachmentServiceException : Xeption
    {
        public FailedAssignmentAttachmentServiceException(Exception innerException)
            : base(message: "Failed assignment attachemnt service error occurred, contact support.",
                  innerException)
        { }
    }
}
