// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;
using Xeptions;

namespace ExamsBot.Models.Assignments.Exceptions
{
    public class InvalidAssignmentException : Exception
    {
        public InvalidAssignmentException(string parameterName, object parameterValue)
            : base(message: $"Invalid assignment, " +
                  $"parameter name: {parameterName}, " +
                  $"parameter value: {parameterValue}.")
        { }
    }
}
