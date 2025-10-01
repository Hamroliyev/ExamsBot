// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Models.Exams;
using ExamsBot.Models.TelegramUsers;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamsBot.Models.Results
{
    public class Result
    {
        public Guid ResultId { get; set; }
        public Guid StudentId { get; set; }
        public Guid ExamId { get; set; }
        public string StudentAnswers { get; set; } // Format: "1A2B3C4D..."
        public int CorrectCount { get; set; }
        public int WrongCount { get; set; }
        public decimal Score { get; set; }
        public string Grade { get; set; }
        public DateTime SubmittedAt { get; set; }
        public TimeSpan TimeTaken { get; set; }

        // Navigation properties
        [ForeignKey(nameof(StudentId))]
        public TelegramUser Student { get; set; }

        [ForeignKey(nameof(ExamId))]
        public Exam Exam { get; set; }
    }
}