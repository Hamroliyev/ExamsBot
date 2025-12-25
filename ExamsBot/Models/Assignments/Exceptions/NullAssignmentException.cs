// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;
using Xeptions;

namespace ExamsBot.Models.Assignments.Exceptions
{
    public class NullAssignmentException : Xeption
    {
        public NullAssignmentException() 
            : base(message: "The assignment is null.") 
        { }
    }
}
