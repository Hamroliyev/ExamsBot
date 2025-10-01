// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Models.Exams;
using ExamsBot.Models.TelegramUsers;
using ExamsBot.Services.Foundations.Exams;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ExamsBot.Services.Processings.Exams
{
    public partial class ExamProcessingService : IExamProcessingService
    {
        private readonly IExamService examService;

        public ExamProcessingService(IExamService examService)
        {
            this.examService = examService;
        }

        public async ValueTask<Exam> UpsertExamAsync(Exam exam)
        {
            Exam maybeExam = await this.examService.RetrieveAllExams()
                .FirstOrDefaultAsync(e => e.ExamId == exam.ExamId);

            return maybeExam is null
                ? await this.examService.AddExamAsync(exam)
                : await this.examService.ModifyExamAsync(exam);
        }

        public IQueryable<Exam> RetrieveActiveExams() =>
            this.examService.RetrieveAllExams()
                .Where(e => e.IsActive && e.EndTime > DateTime.UtcNow);

        public IQueryable<Exam> RetrieveExamsByTeacherId(Guid teacherId) =>
            this.examService.RetrieveAllExams()
                .Where(e => e.CreatedByTeacherId == teacherId);

        public async ValueTask<Exam> EndExamAsync(Guid examId)
        {
            Exam exam = await this.examService.RetrieveExamByIdAsync(examId);
            exam.IsActive = false;
            exam.UpdatedDate = DateTime.UtcNow;

            return await this.examService.ModifyExamAsync(exam);
        }
    }
}
