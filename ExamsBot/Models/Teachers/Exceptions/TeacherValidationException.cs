// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using Xeptions;

namespace ExamsBot.Models.Teachers.Exceptions
{
    public class TeacherValidationException : Xeption
    {
        public TeacherValidationException(Xeption innerException)
            : base(message: "Invalid input, contact support.", innerException) { }
    }
}
