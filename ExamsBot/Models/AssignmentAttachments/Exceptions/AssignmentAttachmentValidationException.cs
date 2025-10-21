// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;

namespace ExamsBot.Models.AssignmentAttachments.Exceptions
{
    public class AssignmentAttachmentValidationException : Exception
    {
        public AssignmentAttachmentValidationException(Exception innerException)
            : base(message: "Invalid input, contact support.", innerException) { }
    }
}
