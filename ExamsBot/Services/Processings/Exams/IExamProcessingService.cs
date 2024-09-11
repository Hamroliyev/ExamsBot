// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Models.Exams;
using System.Threading.Tasks;

namespace ExamsBot.Services.Processings.Exams
{
    public interface IExamProcessingService
    {
        ValueTask<Exam> ModifyTelegramUserAsync(Exam exam);
        ValueTask<Exam> UpsertTelegramUserProcessingService(Exam exam);
    }
}
