// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;
using ExamsBot.Models.Contacts;
using ExamsBot.Models.Teachers;

namespace ExamsBot.Models.TeacherContacts
{
    public class TeacherContact
    {
        public Guid ContactId { get; set; }
        public Contact Contact { get; set; }
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
