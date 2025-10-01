// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Models.Results;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ExamsBot.Services.Processings.Results
{
    public interface IResultProcessingService
    {
        ValueTask<Result> SubmitExamAsync(Result result);
        IQueryable<Result> RetrieveExamResultsAsync(Guid examId);
        IQueryable<Result> RetrieveStudentResultsAsync(Guid studentId);
        ValueTask<Result> CalculateScoreAsync(Result result, string correctAnswers);
    }
}
