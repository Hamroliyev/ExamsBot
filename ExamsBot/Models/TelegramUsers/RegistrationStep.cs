// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

namespace ExamsBot.Models.TelegramUsers
{
    public enum RegistrationStep
    {
        NotStarted = 0,
        WaitingForFullName = 1,
        WaitingForRole = 2,        // Choose Student or Teacher
        WaitingForPhoneNumber = 3, // Optional
        Completed = 10
    }
}
