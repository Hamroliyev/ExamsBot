// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;
using Xeptions;

namespace ExamsBot.Models.Exams.Exceptions
{
    public class FailedExamServiceException : Xeption
    {
        public FailedExamServiceException(Exception innerException)
            : base(message: "Failed exam service error occurred, contact support",
                  innerException)
        { }
    }
}
