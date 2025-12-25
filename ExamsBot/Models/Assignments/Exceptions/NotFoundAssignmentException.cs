// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;

namespace ExamsBot.Models.Assignments.Exceptions
{
    public class NotFoundAssignmentException : Xeption
    {
        public NotFoundAssignmentException(Guid assignmentId)
            : base(message: $"Couldn't find assignment with id: {assignmentId}.") 
        { }
    }
}
