// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;
using ExamsBot.Models.Contacts;
using ExamsBot.Models.Students;

namespace ExamsBot.Models.StudentContacts
{
    public class StudentContact
    {
        public Guid ContactId { get; set; }
        public Contact Contact { get; set; }

        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
