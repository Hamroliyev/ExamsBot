// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Models.Exams;
using System.Threading.Tasks;

namespace ExamsBot.Services.Processings.Exams
{
    public interface IExamProcessingService
    {
        ValueTask<Exam> ModifyExamAsync(Exam exam);
        ValueTask<Exam> UpsertExamProcessingService(Exam exam);
    }
}
