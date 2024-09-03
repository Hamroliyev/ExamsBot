// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;
using System;
using ExamsBot.Models.Exams;

namespace ExamsBot.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Exam> InsertExamAsync(Exam exam);
        IQueryable<Exam> SelectAllExams();
        ValueTask<Exam> SelectExamByIdAsync(Guid examId);
        ValueTask<Exam> UpdateExamAsync(Exam exam);
        ValueTask<Exam> DeleteExamAsync(Exam exam);
    }
}
