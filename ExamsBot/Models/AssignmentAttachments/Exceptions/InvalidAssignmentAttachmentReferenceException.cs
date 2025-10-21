// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;

namespace ExamsBot.Models.AssignmentAttachments.Exceptions
{
    public class InvalidAssignmentAttachmentReferenceException : Exception
    {
        public InvalidAssignmentAttachmentReferenceException(Exception innerException)
            : base(message: "Invalid assignment attachment reference error occurred.", innerException) { }
    }
}
