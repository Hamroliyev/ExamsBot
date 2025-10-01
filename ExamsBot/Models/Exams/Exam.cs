// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Models.Results;
using ExamsBot.Models.TelegramUsers;
using System;
using System.Collections.Generic;

namespace ExamsBot.Models.Exams
{
    public class Exam
    {
        public Guid ExamId { get; set; }
        public string ExamName { get; set; }
        public string Description { get; set; }
        public int QuestionCount { get; set; }
        public string CorrectAnswers { get; set; } // Format: "1A2B3C4D..."
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsActive { get; set; }
        public Guid CreatedByTeacherId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        // Navigation properties
        public TelegramUser Teacher { get; set; }
        public ICollection<Result> Results { get; set; }
    }
}