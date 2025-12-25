// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;

namespace ExamsBot.Models.Assignments.Exceptions
{
    public class AlreadyExistsAssignmentException : Xeption
    {
        public AlreadyExistsAssignmentException(Exception innerException)
            : base(message: "Assignment with the same id already exists.", innerException) 
        { }
    }
}
