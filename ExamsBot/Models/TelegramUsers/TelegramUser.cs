// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ExamsBot.Models.Assignments;
using ExamsBot.Models.Exams;
using ExamsBot.Models.Results;
using ExamsBot.Models.TelegramUserMessages;

namespace ExamsBot.Models.TelegramUsers
{
    public class TelegramUser
    {
        public Guid Id { get; set; }

        [Required]
        public long TelegramId { get; set; } // Unique Telegram ID

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string Username { get; set; } // @username

        [Phone]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        // Computed full name
        public string FullName => string.IsNullOrWhiteSpace(LastName)
            ? FirstName
            : $"{FirstName} {LastName}";

        // Role: Student, Teacher, or Admin
        [Required]
        public TelegramUserRole Role { get; set; }

        // Registration tracking
        public bool IsFullyRegistered { get; set; }
        public RegistrationStep CurrentRegistrationStep { get; set; }
        public bool IsActive { get; set; } = true;

        // Timestamps
        public DateTime RegisteredAt { get; set; }
        public DateTime LastActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        // If user is a Teacher - exams they created
        public ICollection<Exam> CreatedExams { get; set; } = new List<Exam>();

        // If user is a Student - their assignments
        public ICollection<StudentAssignment> Assignments { get; set; } = new List<StudentAssignment>();

        // If user is a Student - their results
        public ICollection<Result> Results { get; set; } = new List<Result>();

        // Messages for audit trail
        public ICollection<TelegramUserMessage> Messages { get; set; } = new List<TelegramUserMessage>();

        // If user is a Parent - their children relationships
        public ICollection<ParentStudentRelationship> ParentRelationships { get; set; } = new List<ParentStudentRelationship>();

        // If user is a Student - parent relationships
        public ICollection<ParentStudentRelationship> StudentRelationships { get; set; } = new List<ParentStudentRelationship>();

        // If user is a Teacher - performance periods they can view
        public ICollection<StudentPerformancePeriod> ViewablePerformancePeriods { get; set; } = new List<StudentPerformancePeriod>();
    }
}
