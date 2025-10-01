// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Models.Exams;
using ExamsBot.Models.Results;
using System;
using System.Collections.Generic;

namespace ExamsBot.Models.TelegramUsers
{
    public class TelegramUser
    {
        public Guid Id { get; set; }
        public long TelegramId { get; set; }
        public string FirstName { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public TelegramUserStatus Status { get; set; }
        public bool IsFullyRegistered { get; set; }
        public DateTime RegisteredAt { get; set; }
        public DateTime LastActive { get; set; }

        // Navigation properties
        public ICollection<Exam> CreatedExams { get; set; } // Exams created by teacher
        public ICollection<Result> Results { get; set; } // Exam results as student
    }
}