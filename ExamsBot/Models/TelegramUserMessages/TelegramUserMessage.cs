// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ExamsBot.Models.TelegramUsers;

namespace ExamsBot.Models.TelegramUserMessages
{
    public class TelegramUserMessage
    {
        public Guid Id { get; set; }

        [Required]
        public Guid TelegramUserId { get; set; }

        // Message details
        public long MessageId { get; set; }
        public long ChatId { get; set; }

        [MaxLength(4096)]
        public string MessageText { get; set; }

        public TelegramUserMessageType MessageType { get; set; }
        public MessageDirection Direction { get; set; }

        // Processing status
        public bool IsProcessed { get; set; }
        [MaxLength(200)]
        public string ProcessingStatus { get; set; }
        public DateTime? ProcessedAt { get; set; }

        // Error tracking
        [MaxLength(1000)]
        public string ErrorMessage { get; set; }
        public int RetryCount { get; set; }

        // Context (what was user doing?)
        [MaxLength(100)]
        public string Context { get; set; } // e.g., "registration", "submitting_answers", "command"

        // Related entities (optional)
        public Guid? RelatedExamId { get; set; }
        public Guid? RelatedAssignmentId { get; set; }

        // Timestamps
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        // Navigation
        [ForeignKey(nameof(TelegramUserId))]
        public TelegramUser TelegramUser { get; set; }
    }
}