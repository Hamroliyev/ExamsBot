// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Models.TelegramUsers;
using System;

namespace ExamsBot.Models.Exams
{
    public class Exam
    {
        public Guid Id { get; set; }
        public int CountOfTests { get; set; }
        public DateTime CreatedDate { get; set; } 
        public Guid TelegramUserId { get; set; }
        public TelegramUser TelegramUser { get; set; }
    }
}
