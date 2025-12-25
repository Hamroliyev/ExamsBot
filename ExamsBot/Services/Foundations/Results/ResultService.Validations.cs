// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using ExamsBot.Models.Results;
using ExamsBot.Models.Results.Exceptions;

namespace ExamsBot.Services.Foundations.Results
{
    public partial class ResultService
    {
        private void ValidateResultOnCreate(Result result)
        {
            ValidateResultIsNull(result);
            ValidateResultIdIsNull(result.ResultId);
            ValidateResultFields(result);
            ValidateInvalidAuditFields(result);
            ValidateAuditFieldsDataOnCreate(result);
            ValidateCreatedDateIsRecent(result);
        }

        private void ValidateResultOnModify(Result result)
        {
            ValidateResultIsNull(result);
            ValidateResultIdIsNull(result.ResultId);
            ValidateResultFields(result);
            ValidateInvalidAuditFields(result);
            ValidateAuditFieldsOnModify(result);
        }

        private static void ValidateStorageResult(Result storageResult, Guid resultId)
        {
            if (storageResult is null)
            {
                throw new NotFoundResultException(resultId);
            }
        }

        private void ValidateCreatedDateIsRecent(Result result)
        {
            if (IsDateNotRecent(result.CreatedAt))
            {
                throw new InvalidResultException(
                    parameterName: nameof(Result.CreatedAt),
                    parameterValue: result.CreatedAt);
            }
        }

        private static void ValidateAuditFieldsDataOnCreate(Result result)
        {
            switch (result)
            {
                case { } when result.UpdatedAt.HasValue && result.UpdatedAt != result.CreatedAt:
                    throw new InvalidResultException(
                    parameterName: nameof(Result.UpdatedAt),
                    parameterValue: result.UpdatedAt);
            }
        }

        private static void ValidateInvalidAuditFields(Result result)
        {
            switch (result)
            {
                case { } when IsInvalid(result.CreatedAt):
                    throw new InvalidResultException(
                    parameterName: nameof(Result.CreatedAt),
                    parameterValue: result.CreatedAt);
            }
        }

        private void ValidateAuditFieldsOnModify(Result result)
        {
            switch (result)
            {
                case { } when !result.UpdatedAt.HasValue:
                    throw new InvalidResultException(
                        parameterName: nameof(Result.UpdatedAt),
                        parameterValue: result.UpdatedAt);

                case { } when result.UpdatedAt.HasValue && IsDateNotRecent(result.UpdatedAt.Value):
                    throw new InvalidResultException(
                        parameterName: nameof(Result.UpdatedAt),
                        parameterValue: result.UpdatedAt);
            }
        }

        private static void ValidateAgainstStorageResultOnModify(Result inputResult, Result storageResult)
        {
            switch (inputResult)
            {
                case { } when inputResult.CreatedAt != storageResult.CreatedAt:
                    throw new InvalidResultException(
                        parameterName: nameof(Result.CreatedAt),
                        parameterValue: inputResult.CreatedAt);

                case { } when inputResult.UpdatedAt == storageResult.UpdatedAt:
                    throw new InvalidResultException(
                        parameterName: nameof(Result.UpdatedAt),
                        parameterValue: inputResult.UpdatedAt);
            }
        }

        private static void ValidateResultFields(Result result)
        {
            if (result.AssignmentId == default)
            {
                throw new InvalidResultException(
                    parameterName: nameof(Result.AssignmentId),
                    parameterValue: result.AssignmentId);
            }

            if (result.StudentId == default)
            {
                throw new InvalidResultException(
                    parameterName: nameof(Result.StudentId),
                    parameterValue: result.StudentId);
            }

            if (result.ExamId == default)
            {
                throw new InvalidResultException(
                    parameterName: nameof(Result.ExamId),
                    parameterValue: result.ExamId);
            }

            if (result.AttemptsCount < 0 || result.AttemptsCount > 3)
            {
                throw new InvalidResultException(
                    parameterName: nameof(Result.AttemptsCount),
                    parameterValue: result.AttemptsCount);
            }

            if (result.ScorePercentage < 0 || result.ScorePercentage > 100)
            {
                throw new InvalidResultException(
                    parameterName: nameof(Result.ScorePercentage),
                    parameterValue: result.ScorePercentage);
            }
        }

        private static void ValidateResultIdIsNull(Guid resultId)
        {
            if (resultId == default)
            {
                throw new InvalidResultException(
                    parameterName: nameof(Result.ResultId),
                    parameterValue: resultId);
            }
        }

        private static void ValidateResultIsNull(Result result)
        {
            if (result is null)
            {
                throw new NullResultException();
            }
        }

        private static bool IsInvalid(DateTime input) => input == default;

        private bool IsDateNotRecent(DateTime date)
        {
            DateTimeOffset currentDateTime =
                this.dateTimeBroker.GetCurrentDateTime();

            TimeSpan timeDifference = currentDateTime.Subtract(date);
            TimeSpan oneMinute = TimeSpan.FromMinutes(1);

            return timeDifference.Duration() > oneMinute;
        }
    }
}

