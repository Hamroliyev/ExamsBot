// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ExamsBot.Models.TelegramUsers;

namespace ExamsBot.Models.Notifications
{
    public class Notification
    {
        public Guid Id { get; set; }

        [Required]
        public Guid RecipientId { get; set; }

        public NotificationType Type { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Message { get; set; }

        // Delivery status
        public bool IsSent { get; set; }
        public DateTime? SentAt { get; set; }

        public bool IsDelivered { get; set; }
        public DateTime? DeliveredAt { get; set; }

        // Retry mechanism
        public int RetryCount { get; set; }
        [MaxLength(500)]
        public string ErrorMessage { get; set; }

        // Context
        public Guid? RelatedExamId { get; set; }
        public Guid? RelatedAssignmentId { get; set; }
        public Guid? RelatedResultId { get; set; }

        public DateTime CreatedAt { get; set; }

        // Navigation
        [ForeignKey(nameof(RecipientId))]
        public TelegramUser Recipient { get; set; }
    }
}
