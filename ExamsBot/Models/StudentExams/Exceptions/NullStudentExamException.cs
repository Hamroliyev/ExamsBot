// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;

namespace ExamsBot.Models.StudentExams.Exceptions
{
    public class NullStudentExamException : Exception
    {
        public NullStudentExamException() : base(message: "The student exam is null.") { }
    }
}
