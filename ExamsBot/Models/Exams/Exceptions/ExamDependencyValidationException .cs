// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using Xeptions;

namespace ExamsBot.Models.Exams.Exceptions
{
    public class ExamDependencyValidationException : Xeption
    {
        public ExamDependencyValidationException(Xeption innerException)
            : base(message: "Exam dependency validation error occurred, fix the errors.", innerException) { }
    }
}
