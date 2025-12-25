// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ExamsBot.Models.TelegramUsers;

namespace ExamsBot.Models.Results
{
    /// <summary>
    /// Aggregated student performance data for time periods (weekly, monthly, yearly)
    /// Used for teacher monitoring and reporting
    /// </summary>
    public class StudentPerformancePeriod
    {
        public Guid Id { get; set; }

        [Required]
        public Guid StudentId { get; set; }

        [Required]
        public Guid TeacherId { get; set; } // Teacher who can view this data

        // Period type
        [Required]
        public PerformancePeriodType PeriodType { get; set; }

        // Period start date
        [Required]
        public DateTime PeriodStartDate { get; set; }

        // Period end date
        [Required]
        public DateTime PeriodEndDate { get; set; }

        // Aggregated statistics
        public int TotalExamsTaken { get; set; }
        public int TotalExamsPassed { get; set; }
        public int TotalExamsFailed { get; set; }

        // Average scores
        [Range(0, 100)]
        public decimal AverageScore { get; set; }

        [Range(0, 100)]
        public decimal HighestScore { get; set; }

        [Range(0, 100)]
        public decimal LowestScore { get; set; }

        // Total attempts across all exams
        public int TotalAttempts { get; set; }

        // Improvement tracking
        public decimal ScoreImprovement { get; set; } // Percentage change from previous period

        // Timestamps
        public DateTime CalculatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        [ForeignKey(nameof(StudentId))]
        public TelegramUser Student { get; set; }

        [ForeignKey(nameof(TeacherId))]
        public TelegramUser Teacher { get; set; }
    }

    public enum PerformancePeriodType
    {
        Weekly = 0,
        Monthly = 1,
        Yearly = 2,
        Custom = 3
    }
}

