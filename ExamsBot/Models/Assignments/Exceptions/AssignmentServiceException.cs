// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;
using Xeptions;

namespace ExamsBot.Models.Assignments.Exceptions
{
    public class AssignmentServiceException : Xeption
    {
        public AssignmentServiceException(Exception innerException)
            : base(message: "Service error occurred, contact support.", innerException) 
        { }
    }
}