// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Brokers.DateTimes;
using ExamsBot.Brokers.Loggings;
using ExamsBot.Brokers.Storages;
using System;
using System.Linq;
using System.Threading.Tasks;
using ExamsBot.Models.Exams;

namespace ExamsBot.Services.Foundations.Exams
{
    public partial class ExamService : IExamService
    {
        private readonly IStorageBroker storageBroker;
        private readonly IDateTimeBroker dateTimeBroker;
        private readonly ILoggingBroker loggingBroker;

        public ExamService(
            IStorageBroker storageBroker,
            IDateTimeBroker dateTimeBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.dateTimeBroker = dateTimeBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Exam> AddExamAsync(Exam exam) =>
            TryCatch(async () =>
            {
                ValidateExamOnCreate(exam);

                return await this.storageBroker.InsertExamAsync(exam);
            });

        public IQueryable<Exam> RetrieveAllExams() =>
            TryCatch(() => this.storageBroker.SelectAllExams());

        public ValueTask<Exam> RetrieveExamByIdAsync(Guid examId) =>
            TryCatch(async () =>
            {
                ValidateExamIdIsNull(examId);
                Exam storageExam = await this.storageBroker.SelectExamByIdAsync(examId);
                ValidateStorageExam(storageExam, examId);

                return storageExam;
            });

        public ValueTask<Exam> ModifyExamAsync(Exam exam) =>
            TryCatch(async () =>
            {
                ValidateExamOnModify(exam);
                Exam maybeExam = await this.storageBroker.SelectExamByIdAsync(exam.ExamId);
                ValidateStorageExam(maybeExam, exam.ExamId);
                ValidateAgainstStorageExamOnModify(inputExam: exam, storageExam: maybeExam);

                return await this.storageBroker.UpdateExamAsync(exam);
            });

        public ValueTask<Exam> RemoveExamAsync(Exam exam) =>
            TryCatch(async () =>
            {
                ValidateExamIsNull(exam);
                ValidateExamIdIsNull(exam.ExamId);
                Exam maybeExam = await this.storageBroker.SelectExamByIdAsync(exam.ExamId);
                ValidateStorageExam(maybeExam, exam.ExamId);

                return await this.storageBroker.DeleteExamAsync(maybeExam);
            });
    }
}
