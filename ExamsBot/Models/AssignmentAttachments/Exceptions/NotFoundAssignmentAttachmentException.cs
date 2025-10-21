// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;

namespace ExamsBot.Models.AssignmentAttachments.Exceptions
{
    public class NotFoundAssignmentAttachmentException : Exception
    {
        public NotFoundAssignmentAttachmentException(Guid assignmentId, Guid attachmentId)
            : base(message: $"Couldn't find assignment attachment with assignment id: " +
                    $"{assignmentId} " +
                    $"and attachment id: {attachmentId}.")
        { }
    }
}
