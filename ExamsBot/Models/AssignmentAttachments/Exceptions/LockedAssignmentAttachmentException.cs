// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;

namespace ExamsBot.Models.AssignmentAttachments.Exceptions
{
    public class LockedAssignmentAttachmentException : Exception
    {
        public LockedAssignmentAttachmentException(Exception innerException)
            : base(message: "Locked assignment attachment record exception, please try again later.",
                  innerException)
        { }
    }
}
