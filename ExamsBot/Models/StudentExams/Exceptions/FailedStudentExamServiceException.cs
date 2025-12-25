// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;
using Xeptions;

namespace ExamsBot.Models.StudentExams.Exceptions
{
    public class FailedStudentExamServiceException : Xeption
    {
        public FailedStudentExamServiceException(Exception innerException)
            : base(message: "Failed student exam service error occurred, contact support.", innerException)
        {
        }
    }
}
