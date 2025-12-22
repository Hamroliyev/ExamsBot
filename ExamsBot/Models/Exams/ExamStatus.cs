// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

namespace ExamsBot.Models.Exams
{
    public enum ExamStatus
    {
        Draft = 0,      // Teacher creating, not visible to students
        Published = 1,  // Assigned to students, accepting submissions
        Closed = 2,     // No longer accepting submissions
        Archived = 3    // Old exam
    }
}
