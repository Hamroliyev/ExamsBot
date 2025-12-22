// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

namespace ExamsBot.Models.Notifications
{
    public enum NotificationType
    {
        AssignmentReceived = 0,  // Student: You have new homework
        AssignmentReminder = 1,  // Student: Homework deadline approaching
        ResultAvailable = 2,     // Student: Your result is ready
        SubmissionReceived = 3,  // Teacher: Student submitted answers
        AllSubmissionsIn = 4,    // Teacher: All students submitted
        DeadlinePassed = 5,      // Teacher/Student: Deadline passed
        SystemAlert = 6          // Admin: System notifications
    }
}
