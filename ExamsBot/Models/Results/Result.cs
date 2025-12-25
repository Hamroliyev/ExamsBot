// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ExamsBot.Models.Assignments;
using ExamsBot.Models.Exams;
using ExamsBot.Models.TelegramUsers;

namespace ExamsBot.Models.Results
{
    public class Result
    {
        public Guid ResultId { get; set; }

        [Required]
        public Guid AssignmentId { get; set; } // Links to specific assignment

        [Required]
        public Guid StudentId { get; set; }

        [Required]
        public Guid ExamId { get; set; }

        // Student's submitted answers in format: "1a2b3c4d..." (from best attempt or latest)
        [MaxLength(500)]
        public string StudentAnswers { get; set; }

        // Number of attempts made by student (1-3)
        public int AttemptsCount { get; set; }

        // Scoring details (moderated/averaged from all attempts)
        public int CorrectCount { get; set; }
        public int WrongCount { get; set; }
        public int TotalQuestions { get; set; }

        // Moderated score: Average of all attempts or best attempt (configurable)
        [Range(0, 100)]
        public decimal ScorePercentage { get; set; }

        // Best attempt score (highest score from all attempts)
        [Range(0, 100)]
        public decimal BestAttemptScore { get; set; }

        // Average score across all attempts
        [Range(0, 100)]
        public decimal AverageAttemptScore { get; set; }

        // Grade (A+, A, B, C, D, F) - based on moderated score
        [MaxLength(5)]
        public string Grade { get; set; }

        public bool IsPassed { get; set; }

        // Timing information (from best/latest attempt)
        public DateTime SubmittedAt { get; set; }
        public DateTime? FirstAttemptAt { get; set; }
        public DateTime? LastAttemptAt { get; set; }
        public TimeSpan? TimeTaken { get; set; }

        // Is this submitted after deadline?
        public bool IsLateSubmission { get; set; }

        // Detailed answer breakdown (JSON format) - from best attempt
        // [{"q":1,"student":"a","correct":"b","isCorrect":false}, ...]
        [MaxLength(2000)]
        public string AnswerDetails { get; set; }

        // All submission attempts (1-3 attempts)
        public ICollection<SubmissionAttempt> SubmissionAttempts { get; set; } = new List<SubmissionAttempt>();

        // Teacher feedback (optional)
        [MaxLength(1000)]
        public string TeacherComment { get; set; }
        public DateTime? CommentedAt { get; set; }
        public Guid? CommentedByTeacherId { get; set; }

        // Result status
        public ResultStatus Status { get; set; } = ResultStatus.Graded;

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

        [ForeignKey(nameof(CommentedByTeacherId))]
        public TelegramUser CommentedByTeacher { get; set; }
    }
}