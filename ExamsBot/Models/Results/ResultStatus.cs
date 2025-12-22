// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

namespace ExamsBot.Models.Results
{
    public enum ResultStatus
    {
        Graded = 0,      // Auto-graded by bot
        Published = 1,   // Result sent to student
        UnderReview = 2, // Teacher reviewing
        Finalized = 3    // Teacher confirmed final grade
    }
}