﻿// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Models.Exams;
using ExamsBot.Models.Results;
using System;
using System.Collections.Generic;

namespace ExamsBot.Models.TelegramUsers
{
    public class TelegramUser
    {
        public Guid Id { get; set; }
        public long TelegramId { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public TelegramUserStatus Status { get; set; }
        public Guid HelperId { get; set; }
        public ICollection<Result> Results { get; set; }
    }
}
