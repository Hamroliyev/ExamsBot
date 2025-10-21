// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;

namespace ExamsBot.Models.AssignmentAttachments.Exceptions
{
    public class NullAssignmentAttachmentException : Exception
    {
        public NullAssignmentAttachmentException()
            : base(message: "The assignment attachment is null.") { }
    }
}
