// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System;
using ExamsBot.Models.Exams;

namespace ExamsBot.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Exam> Exams { get; set; }

        public async ValueTask<Exam> InsertExamAsync(Exam exam) =>
            await InsertAsync(exam);

        public IQueryable<Exam> SelectAllExams() =>
            SelectAll<Exam>();

        public async ValueTask<Exam> SelectExamByIdAsync(Guid examId) =>
            await SelectAsync<Exam>(examId);

        public async ValueTask<Exam> UpdateExamAsync(Exam exam) =>
            await UpdateAsync(exam);

        public async ValueTask<Exam> DeleteExamAsync(Exam exam) =>
            await DeleteAsync(exam);
    }
}
