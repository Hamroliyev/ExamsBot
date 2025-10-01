// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Models.Results;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace ExamsBot.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Result> Results { get; set; }

        public async ValueTask<Result> InsertResultAsync(Result result) =>
            await InsertAsync(result);

        public IQueryable<Result> SelectAllResults() =>
            SelectAll<Result>();

        public async ValueTask<Result> SelectResultByIdAsync(Guid resultId) =>
            await SelectAsync<Result>(resultId);

        public IQueryable<Result> SelectResultsByExamIdAsync(Guid examId) =>
            SelectAll<Result>().Where(r => r.ExamId == examId);

        public IQueryable<Result> SelectResultsByStudentIdAsync(Guid studentId) =>
            SelectAll<Result>().Where(r => r.StudentId == studentId);

        public async ValueTask<Result> UpdateResultAsync(Result result) =>
            await UpdateAsync(result);

        public async ValueTask<Result> DeleteResultAsync(Result result) =>
            await DeleteAsync(result);
    }
}