// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamsBot.Models.TelegramUsers
{
    /// <summary>
    /// Links a Parent TelegramUser to their Student children
    /// Allows parents to view their children's exam results and performance
    /// </summary>
    public class ParentStudentRelationship
    {
        public Guid ParentStudentRelationshipId { get; set; }

        [Required]
        public Guid ParentId { get; set; } // TelegramUser with Parent role

        [Required]
        public Guid StudentId { get; set; } // TelegramUser with Student role

        // Relationship type
        [MaxLength(50)]
        public string RelationshipType { get; set; } // e.g., "Father", "Mother", "Guardian"

        // Is this relationship verified/approved?
        public bool IsVerified { get; set; } = false;

        // Who verified this relationship? (Admin or Teacher)
        public Guid? VerifiedBy { get; set; }
        public DateTime? VerifiedAt { get; set; }

        // Timestamps
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        [ForeignKey(nameof(ParentId))]
        public TelegramUser Parent { get; set; }

        [ForeignKey(nameof(StudentId))]
        public TelegramUser Student { get; set; }

        [ForeignKey(nameof(VerifiedBy))]
        public TelegramUser VerifiedByUser { get; set; }
    }
}

