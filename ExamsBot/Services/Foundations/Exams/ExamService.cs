// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Brokers.Storages;
using System.Linq;
using System.Threading.Tasks;
using System;
using ExamsBot.Models.Exams;

namespace ExamsBot.Services.Foundations.Exams
{
    public class ExamService : IExamService
    {
        private readonly IStorageBroker storageBroker;

        public ExamService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }
        public async ValueTask<Exam> AddExamAsync(Exam exam) =>
            await storageBroker.InsertExamAsync(exam);

        public IQueryable<Exam> RetriveAllExams() =>
            storageBroker.SelectAllExams();

        public ValueTask<Exam> RetrieveExamByIdAsync(Guid examId) =>
            storageBroker.SelectExamByIdAsync(examId);

        public ValueTask<Exam> ModifyExamAsync(Exam exam) =>
            storageBroker.UpdateExamAsync(exam);

        public async ValueTask<Exam> RemoveExamAsync(Exam exam) =>
            await storageBroker.DeleteExamAsync(exam);
    }
}
