// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;
using ExamsBot.Models.Registrations;
using ExamsBot.Models.Students;

namespace ExamsBot.Models.StudentRegistrations
{
    public class StudentRegistration
    {
        public Guid StudentId { get; set; }
        public Student Student { get; set; }

        public Guid RegistrationId { get; set; }
        public Registration Registration { get; set; }
    }
}
