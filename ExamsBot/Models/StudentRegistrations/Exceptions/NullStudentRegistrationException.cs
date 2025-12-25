// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;

namespace ExamsBot.Models.StudentRegistrations.Exceptions
{
    public class NullStudentRegistrationException : Exception
    {
        public NullStudentRegistrationException() : base(message: "The student registration is null.") { }
    }
}
