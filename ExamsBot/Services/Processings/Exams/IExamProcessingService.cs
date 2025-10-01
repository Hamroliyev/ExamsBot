// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Models.Exams;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ExamsBot.Services.Processings.Exams
{
    public interface IExamProcessingService
    {
        ValueTask<Exam> EndExamAsync(Guid examId);
        IQueryable<Exam> RetrieveActiveExams();
        IQueryable<Exam> RetrieveExamsByTeacherId(Guid teacherId);
        ValueTask<Exam> UpsertExamAsync(Exam exam);
    }
}