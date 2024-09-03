// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;
using System;
using ExamsBot.Models.Exams;

namespace ExamsBot.Services.Foundations.Exams
{
    public interface IExamService
    {
        ValueTask<Exam> AddExamAsync(Exam exam);
        IQueryable<Exam> RetriveAllExams();
        ValueTask<Exam> RetrieveExamByIdAsync(Guid examId);
        ValueTask<Exam> ModifyExamAsync(Exam exam);
        ValueTask<Exam> RemoveExamAsync(Exam exam);
    }
}
