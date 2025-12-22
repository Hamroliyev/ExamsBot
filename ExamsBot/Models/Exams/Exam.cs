// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ExamsBot.Models.Assignments;
using ExamsBot.Models.Results;
using ExamsBot.Models.TelegramUsers;

namespace ExamsBot.Models.Exams
{
    public class Exam
    {
        public Guid ExamId { get; set; }

        [Required]
        [MaxLength(200)]
        public string ExamName { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [Range(1, 100)]
        public int QuestionCount { get; set; }

        // Correct answers in format: "1a2b3c4d..."
        [Required]
        [MaxLength(500)]
        public string CorrectAnswers { get; set; }

        // Exam status
        public ExamStatus Status { get; set; } = ExamStatus.Draft;

        // Optional time limit (in minutes)
        public int? TimeLimitMinutes { get; set; }

        // Optional deadline for submission
        public DateTime? Deadline { get; set; }

        // Teacher who created this exam
        [Required]
        public Guid CreatedByTeacherId { get; set; }

        // Timestamps
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime? PublishedAt { get; set; }  // When teacher published it
        public DateTime? ClosedAt { get; set; }     // When teacher closed it

        // Statistics
        public int TotalAssignments { get; set; }    // How many students assigned
        public int CompletedCount { get; set; }      // How many submitted
        public decimal AverageScore { get; set; }

        // Navigation properties
        [ForeignKey(nameof(CreatedByTeacherId))]
        public TelegramUser Teacher { get; set; }

        // All assignments of this exam to students
        public ICollection<StudentAssignment> Assignments { get; set; } = new List<StudentAssignment>();

        // All results from students
        public ICollection<Result> Results { get; set; } = new List<Result>();
    }
}