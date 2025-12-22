// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

namespace ExamsBot.Models.Assignments
{
    public enum AssignmentStatus
    {
        Assigned = 0,    // Teacher assigned, student not started yet
        InProgress = 1,  // Student started (optional status)
        Submitted = 2,   // Student submitted answers
        Graded = 3,      // Bot graded and result sent
        Late = 4,        // Submitted after deadline
        Missed = 5       // Not submitted, deadline passed
    }
}
