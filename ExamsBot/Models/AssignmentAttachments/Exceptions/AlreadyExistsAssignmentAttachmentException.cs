// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;

namespace ExamsBot.Models.AssignmentAttachments.Exceptions
{
    public class AlreadyExistsAssignmentAttachmentException : Exception
    {
        public AlreadyExistsAssignmentAttachmentException(Exception innerException)
            : base(message: "Assignment attachment with the same id already exists.", innerException) { }
    }
}
