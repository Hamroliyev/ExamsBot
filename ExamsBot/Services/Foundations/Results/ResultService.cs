// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Brokers.Storages;
using ExamsBot.Models.Results;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ExamsBot.Services.Foundations.Results
{
    public class ResultService : IResultService
    {
        private readonly IStorageBroker storageBroker;

        public ResultService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public async ValueTask<Result> AddResultAsync(Result result) =>
            await this.storageBroker.InsertResultAsync(result);

        public IQueryable<Result> RetrieveAllResults() =>
            this.storageBroker.SelectAllResults();

        public async ValueTask<Result> RetrieveResultByIdAsync(Guid resultId) =>
            await this.storageBroker.SelectResultByIdAsync(resultId);

        public IQueryable<Result> RetrieveResultsByExamIdAsync(Guid examId) =>
            this.storageBroker.SelectResultsByExamIdAsync(examId);

        public IQueryable<Result> RetrieveResultsByStudentIdAsync(Guid studentId) =>
            this.storageBroker.SelectResultsByStudentIdAsync(studentId);

        public async ValueTask<Result> ModifyResultAsync(Result result) =>
            await this.storageBroker.UpdateResultAsync(result);

        public async ValueTask<Result> RemoveResultAsync(Result result) =>
            await this.storageBroker.DeleteResultAsync(result);
    }
}
