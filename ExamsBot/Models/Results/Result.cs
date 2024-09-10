// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Models.Exams;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using ExamsBot.Models.TelegramUsers;

namespace ExamsBot.Models.Results
{
    public class Result
    {
        public int ResultId { get; set; }
        public int StudentId { get; set; }
        public Guid ExamId { get; set; }
        public decimal Score { get; set; }
        public string Grade { get; set; }
        public TelegramUser TelegramUser { get; set; }
        public Exam Exam { get; set; }
    }
}
