// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;

namespace ExamsBot.Models.AssignmentAttachments.Exceptions
{
    public class InvalidAssignmentAttachmentException : Exception
    {
        public InvalidAssignmentAttachmentException(string parameterName, object parameterValue)
            : base(message: $"Invalid assignment attachment, " +
                 $"parameter name: {parameterName}, " +
                 $"parameter value: {parameterValue}.")
        { }
    }
}
