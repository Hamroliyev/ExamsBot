// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Brokers.DateTimes;
using ExamsBot.Brokers.Loggings;
using ExamsBot.Brokers.Storages;
using System;
using System.Linq;
using System.Threading.Tasks;
using ExamsBot.Models.Results;

namespace ExamsBot.Services.Foundations.Results
{
    public partial class ResultService : IResultService
    {
        private readonly IStorageBroker storageBroker;
        private readonly IDateTimeBroker dateTimeBroker;
        private readonly ILoggingBroker loggingBroker;

        public ResultService(
            IStorageBroker storageBroker,
            IDateTimeBroker dateTimeBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.dateTimeBroker = dateTimeBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Result> AddResultAsync(Result result) =>
            TryCatch(async () =>
            {
                ValidateResultOnCreate(result);

                return await this.storageBroker.InsertResultAsync(result);
            });

        public IQueryable<Result> RetrieveAllResults() =>
            TryCatch(() => this.storageBroker.SelectAllResults());

        public ValueTask<Result> RetrieveResultByIdAsync(Guid resultId) =>
            TryCatch(async () =>
            {
                ValidateResultIdIsNull(resultId);
                Result storageResult = await this.storageBroker.SelectResultByIdAsync(resultId);
                ValidateStorageResult(storageResult, resultId);

                return storageResult;
            });

        public IQueryable<Result> RetrieveResultsByExamIdAsync(Guid examId) =>
            TryCatch(() => this.storageBroker.SelectAllResults()
                .Where(result => result.ExamId == examId));

        public IQueryable<Result> RetrieveResultsByStudentIdAsync(Guid studentId) =>
            TryCatch(() => this.storageBroker.SelectAllResults()
                .Where(result => result.StudentId == studentId));

        public ValueTask<Result> ModifyResultAsync(Result result) =>
            TryCatch(async () =>
            {
                ValidateResultOnModify(result);
                Result maybeResult = await this.storageBroker.SelectResultByIdAsync(result.ResultId);
                ValidateStorageResult(maybeResult, result.ResultId);
                ValidateAgainstStorageResultOnModify(inputResult: result, storageResult: maybeResult);

                return await this.storageBroker.UpdateResultAsync(result);
            });

        public ValueTask<Result> RemoveResultAsync(Result result) =>
            TryCatch(async () =>
            {
                ValidateResultIsNull(result);
                ValidateResultIdIsNull(result.ResultId);
                Result maybeResult = await this.storageBroker.SelectResultByIdAsync(result.ResultId);
                ValidateStorageResult(maybeResult, result.ResultId);

                return await this.storageBroker.DeleteResultAsync(maybeResult);
            });
    }
}
