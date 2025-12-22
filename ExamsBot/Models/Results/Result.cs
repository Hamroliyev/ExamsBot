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
    public class Result
    {
        public Guid ResultId { get; set; }

        [Required]
        public Guid AssignmentId { get; set; } // Links to specific assignment

        [Required]
        public Guid StudentId { get; set; }

        [Required]
        public Guid ExamId { get; set; }

        // Student's submitted answers in format: "1a2b3c4d..."
        [Required]
        [MaxLength(500)]
        public string StudentAnswers { get; set; }

        // Scoring details
        public int CorrectCount { get; set; }
        public int WrongCount { get; set; }
        public int TotalQuestions { get; set; }

        // Score as percentage (0-100)
        [Range(0, 100)]
        public decimal ScorePercentage { get; set; }

        // Grade (A+, A, B, C, D, F)
        [MaxLength(5)]
        public string Grade { get; set; }

        public bool IsPassed { get; set; }

        // Timing information
        public DateTime SubmittedAt { get; set; }
        public TimeSpan? TimeTaken { get; set; }

        // Is this submitted after deadline?
        public bool IsLateSubmission { get; set; }

        // Detailed answer breakdown (JSON format)
        // [{"q":1,"student":"a","correct":"b","isCorrect":false}, ...]
        [MaxLength(2000)]
        public string AnswerDetails { get; set; }

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