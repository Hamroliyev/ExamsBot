// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;

namespace ExamsBot.Models.StudentExams.Exceptions
{
    public class InvalidStudentExamException : Exception
    {
        public InvalidStudentExamException(string parameterName, object parameterValue)
            : base(message: $"Invalid student exam, " +
                  $"parameter name: {parameterName}, " +
                  $"parameter value: {parameterValue}.")
        { }
    }
}
