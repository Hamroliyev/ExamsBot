// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ExamsBot.Models.TelegramUsers;

namespace ExamsBot.Models.Admin
{
    public class AdminLog
    {
        public Guid Id { get; set; }

        [Required]
        public Guid AdminId { get; set; }

        [Required]
        public AdminAction Action { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        // What was affected?
        public Guid? AffectedUserId { get; set; }
        public Guid? AffectedExamId { get; set; }

        // Additional details (JSON)
        [MaxLength(2000)]
        public string Details { get; set; }

        public DateTime CreatedAt { get; set; }

        // Navigation
        [ForeignKey(nameof(AdminId))]
        public TelegramUser Admin { get; set; }
    }

    public enum AdminAction
    {
        UserCreated = 0,
        UserUpdated = 1,
        UserDeleted = 2,
        UserBlocked = 3,
        UserUnblocked = 4,
        ExamDeleted = 5,
        ExamArchived = 6,
        AssignmentDeleted = 7,
        ResultModified = 8,
        SystemConfigChanged = 9,
        BulkOperation = 10
    }
}
