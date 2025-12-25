// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ExamsBot.Models.Assignments;
using ExamsBot.Models.Exams;
using ExamsBot.Models.TelegramUsers;

namespace ExamsBot.Models.Results
{
    /// <summary>
    /// Tracks individual submission attempts by a student
    /// Students can submit up to 3 times, all attempts are considered for final moderated score
    /// </summary>
    public class SubmissionAttempt
    {
        public Guid SubmissionAttemptId { get; set; }

        [Required]
        public Guid AssignmentId { get; set; }

        [Required]
        public Guid StudentId { get; set; }

        [Required]
        public Guid ExamId { get; set; }

        // Attempt number (1, 2, or 3)
        [Required]
        [Range(1, 3)]
        public int AttemptNumber { get; set; }

        // Student's submitted answers in format: "1a2b3c4d..."
        [Required]
        [MaxLength(500)]
        public string StudentAnswers { get; set; }

        // Test key used for this submission
        [Required]
        [MaxLength(50)]
        public string TestKeyUsed { get; set; }

        // Scoring details for this attempt
        public int CorrectCount { get; set; }
        public int WrongCount { get; set; }
        public int TotalQuestions { get; set; }

        // Score as percentage (0-100) for this attempt
        [Range(0, 100)]
        public decimal ScorePercentage { get; set; }

        // Grade for this attempt (A+, A, B, C, D, F)
        [MaxLength(5)]
        public string Grade { get; set; }

        // Timing information
        public DateTime SubmittedAt { get; set; }
        public TimeSpan? TimeTaken { get; set; }

        // Is this submitted after deadline?
        public bool IsLateSubmission { get; set; }

        // Detailed answer breakdown (JSON format)
        // [{"q":1,"student":"a","correct":"b","isCorrect":false}, ...]
        // Note: Store as JSON string, validate and parse in service layer
        [MaxLength(2000)]
        public string AnswerDetails { get; set; }

        // Is this attempt the best one?
        public bool IsBestAttempt { get; set; }

        // Audit timestamps
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        [ForeignKey(nameof(AssignmentId))]
        public StudentAssignment Assignment { get; set; }

        [ForeignKey(nameof(StudentId))]
        public TelegramUser Student { get; set; }

        [ForeignKey(nameof(ExamId))]
        public Exam Exam { get; set; }
    }
}

