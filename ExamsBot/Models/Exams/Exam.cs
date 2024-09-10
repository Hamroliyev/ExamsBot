// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Models.Results;
using System;
using System.Collections.Generic;

namespace ExamsBot.Models.Exams
{
    public class Exam
    {
        public Guid ExamId { get; set; }
        public string ExamName { get; set; }
        public int Duration { get; set; }
        public string CorrectAnswers { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<Result> Results { get; set; }
    }
}
