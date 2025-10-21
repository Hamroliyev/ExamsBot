// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;

namespace ExamsBot.Models.AssignmentAttachments.Exceptions
{
    public class AssignmentAttachmentDependencyValidationException : Exception
    {
        public AssignmentAttachmentDependencyValidationException(Exception innerException)
            : base(message: "System dependency validation failure, contact support.", innerException) { }
    }
}
