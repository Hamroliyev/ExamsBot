// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

namespace ExamsBot.Models.Notifications
{
    public enum NotificationType
    {
        TestCreated = 0,         // Student: New test created by teacher (with test key)
        AssignmentReceived = 1,  // Student: You have new homework
        AssignmentReminder = 2,  // Student: Homework deadline approaching
        ResultAvailable = 3,     // Student: Your result is ready
        SubmissionReceived = 4,  // Teacher: Student submitted answers
        AllSubmissionsIn = 5,    // Teacher: All students submitted
        DeadlinePassed = 6,      // Teacher/Student: Deadline passed
        SystemAlert = 7          // Admin: System notifications
    }
}
