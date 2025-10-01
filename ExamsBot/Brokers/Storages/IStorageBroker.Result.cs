// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Models.Results;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace ExamsBot.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Result> InsertResultAsync(Result result);
        IQueryable<Result> SelectAllResults();
        ValueTask<Result> SelectResultByIdAsync(Guid resultId);
        IQueryable<Result> SelectResultsByExamIdAsync(Guid examId);
        IQueryable<Result> SelectResultsByStudentIdAsync(Guid studentId);
        ValueTask<Result> UpdateResultAsync(Result result);
        ValueTask<Result> DeleteResultAsync(Result result);
    }
}