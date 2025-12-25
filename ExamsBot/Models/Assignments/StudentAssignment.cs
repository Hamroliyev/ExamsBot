// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ExamsBot.Models.Exams;
using ExamsBot.Models.Results;
using ExamsBot.Models.TelegramUsers;

namespace ExamsBot.Models.Assignments
{
    /// <summary>
    /// Represents a homework assignment: Teacher assigns an Exam to a Student
    /// Student can only submit answers for exams assigned to them
    /// </summary>
    public class StudentAssignment
    {
        public Guid AssignmentId { get; set; }

        [Required]
        public Guid StudentId { get; set; }

        [Required]
        public Guid ExamId { get; set; }

        [Required]
        public Guid AssignedByTeacherId { get; set; }

        // Assignment status
        public AssignmentStatus Status { get; set; } = AssignmentStatus.Assigned;

        // Test key for this assignment (student uses this to submit)
        [MaxLength(50)]
        public string TestKey { get; set; } // Key given by teacher to student

        // Attempt tracking
        public int AttemptsUsed { get; set; } = 0; // How many attempts student has made (0-3)
        public int MaxAttemptsAllowed { get; set; } = 3; // Max attempts (from exam or override)

        // Timestamps
        public DateTime AssignedAt { get; set; }
        public DateTime? StartedAt { get; set; }      // When student started first attempt
        public DateTime? SubmittedAt { get; set; }    // When student submitted last attempt
        public DateTime? CompletedAt { get; set; }    // When graded (all attempts processed)

        // Optional: Student-specific deadline (overrides exam deadline)
        public DateTime? CustomDeadline { get; set; }

        // Notes from teacher
        [MaxLength(500)]
        public string TeacherNotes { get; set; }

        // Notification tracking
        public bool NotificationSent { get; set; }
        public DateTime? NotificationSentAt { get; set; }

        // Navigation properties
        [ForeignKey(nameof(StudentId))]
        public TelegramUser Student { get; set; }

        [ForeignKey(nameof(ExamId))]
        public Exam Exam { get; set; }

        [ForeignKey(nameof(AssignedByTeacherId))]
        public TelegramUser AssignedByTeacher { get; set; }

        // The result for this assignment (one-to-one)
        // Contains moderated score from all attempts
        public Result Result { get; set; }

        // All submission attempts (up to 3)
        public ICollection<SubmissionAttempt> SubmissionAttempts { get; set; } = new List<SubmissionAttempt>();
    }
}
