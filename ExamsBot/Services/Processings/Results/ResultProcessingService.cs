// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Models.Results;
using ExamsBot.Services.Foundations.Results;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ExamsBot.Services.Processings.Results
{
    public class ResultProcessingService : IResultProcessingService
    {
        private readonly IResultService resultService;

        public ResultProcessingService(IResultService resultService)
        {
            this.resultService = resultService;
        }

        public async ValueTask<Result> SubmitExamAsync(Result result)
        {
            result.SubmittedAt = DateTime.UtcNow;
            return await this.resultService.AddResultAsync(result);
        }

        public IQueryable<Result> RetrieveExamResultsAsync(Guid examId) =>
            this.resultService.RetrieveResultsByExamIdAsync(examId);

        public IQueryable<Result> RetrieveStudentResultsAsync(Guid studentId) =>
            this.resultService.RetrieveResultsByStudentIdAsync(studentId);

        public async ValueTask<Result> CalculateScoreAsync(Result result, string correctAnswers)
        {
            var studentAnswers = result.StudentAnswers;
            int correctCount = 0;
            int wrongCount = 0;

            // Simple answer comparison logic (format: "1A2B3C4D...")
            for (int i = 0; i < Math.Min(studentAnswers.Length, correctAnswers.Length); i += 2)
            {
                if (i + 1 < studentAnswers.Length && i + 1 < correctAnswers.Length)
                {
                    if (char.ToUpper(studentAnswers[i + 1]) == char.ToUpper(correctAnswers[i + 1]))
                        correctCount++;
                    else
                        wrongCount++;
                }
            }

            result.CorrectCount = correctCount;
            result.WrongCount = wrongCount;
            result.Score = (decimal)correctCount / (correctCount + wrongCount) * 100;
            result.Grade = CalculateGrade(result.Score);

            return await this.resultService.ModifyResultAsync(result);
        }

        private string CalculateGrade(decimal score) => score switch
        {
            >= 90 => "A",
            >= 80 => "B",
            >= 70 => "C",
            >= 60 => "D",
            _ => "F"
        };
    }
}
