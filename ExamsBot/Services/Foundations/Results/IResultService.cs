// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Models.Results;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ExamsBot.Services.Foundations.Results
{
    public interface IResultService
    {
        ValueTask<Result> AddResultAsync(Result result);
        IQueryable<Result> RetrieveAllResults();
        ValueTask<Result> RetrieveResultByIdAsync(Guid resultId);
        IQueryable<Result> RetrieveResultsByExamIdAsync(Guid examId);
        IQueryable<Result> RetrieveResultsByStudentIdAsync(Guid studentId);
        ValueTask<Result> ModifyResultAsync(Result result);
        ValueTask<Result> RemoveResultAsync(Result result);
    }
}
