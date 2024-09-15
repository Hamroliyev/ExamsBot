// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Models.Exams;
using ExamsBot.Models.TelegramUsers;
using ExamsBot.Services.Foundations.Exams;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ExamsBot.Services.Processings.Exams
{
    public class ExamProcessingService : IExamProcessingService
    {
        private readonly IExamService examService;
        public ExamProcessingService(IExamService examService)
        {
            this.examService = examService;
        }
        public async ValueTask<Exam> ModifyExamAsync(Exam exam) =>
            await this.examService.ModifyExamAsync(exam);

        public async ValueTask<Exam> UpsertExamProcessingService(Exam exam)
        {
            Exam maybeExam = await examService.RetriveAllExams()
                .FirstOrDefaultAsync(e => e.ExamId == exam.ExamId);

            return maybeExam is null
                ? await this.examService.AddExamAsync(exam)
                : maybeExam;
        }
    }
}
