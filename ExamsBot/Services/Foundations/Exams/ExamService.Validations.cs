// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using ExamsBot.Models.Exams;
using ExamsBot.Models.Exams.Exceptions;

namespace ExamsBot.Services.Foundations.Exams
{
    public partial class ExamService
    {
        private void ValidateExamOnCreate(Exam exam)
        {
            ValidateExamIsNull(exam);
            ValidateExamIdIsNull(exam.ExamId);
            ValidateExamFields(exam);
            ValidateInvalidAuditFields(exam);
            ValidateAuditFieldsDataOnCreate(exam);
            ValidateCreatedDateIsRecent(exam);
        }

        private void ValidateExamOnModify(Exam exam)
        {
            ValidateExamIsNull(exam);
            ValidateExamIdIsNull(exam.ExamId);
            ValidateExamFields(exam);
            ValidateInvalidAuditFields(exam);
            ValidateAuditFieldsOnModify(exam);
        }

        private static void ValidateStorageExam(Exam storageExam, Guid examId)
        {
            if (storageExam is null)
            {
                throw new NotFoundExamException(examId);
            }
        }

        private void ValidateCreatedDateIsRecent(Exam exam)
        {
            if (IsDateNotRecent(exam.CreatedDate))
            {
                throw new InvalidExamException(
                    parameterName: nameof(Exam.CreatedDate),
                    parameterValue: exam.CreatedDate);
            }
        }

        private static void ValidateAuditFieldsDataOnCreate(Exam exam)
        {
            switch (exam)
            {
                case { } when exam.UpdatedDate != exam.CreatedDate:
                    throw new InvalidExamException(
                    parameterName: nameof(Exam.UpdatedDate),
                    parameterValue: exam.UpdatedDate);
            }
        }

        private static void ValidateInvalidAuditFields(Exam exam)
        {
            switch (exam)
            {
                case { } when IsInvalid(exam.CreatedDate):
                    throw new InvalidExamException(
                    parameterName: nameof(Exam.CreatedDate),
                    parameterValue: exam.CreatedDate);
                case { } when IsInvalid(exam.UpdatedDate):
                    throw new InvalidExamException(
                    parameterName: nameof(Exam.UpdatedDate),
                    parameterValue: exam.UpdatedDate);
            }
        }

        private void ValidateAuditFieldsOnModify(Exam exam)
        {
            switch (exam)
            {
                case { } when exam.UpdatedDate == exam.CreatedDate:
                    throw new InvalidExamException(
                        parameterName: nameof(Exam.UpdatedDate),
                        parameterValue: exam.UpdatedDate);

                case { } when IsDateNotRecent(exam.UpdatedDate):
                    throw new InvalidExamException(
                        parameterName: nameof(Exam.UpdatedDate),
                        parameterValue: exam.UpdatedDate);
            }
        }

        private static void ValidateAgainstStorageExamOnModify(Exam inputExam, Exam storageExam)
        {
            switch (inputExam)
            {
                case { } when inputExam.CreatedDate != storageExam.CreatedDate:
                    throw new InvalidExamException(
                        parameterName: nameof(Exam.CreatedDate),
                        parameterValue: inputExam.CreatedDate);

                case { } when inputExam.UpdatedDate == storageExam.UpdatedDate:
                    throw new InvalidExamException(
                        parameterName: nameof(Exam.UpdatedDate),
                        parameterValue: inputExam.UpdatedDate);
            }
        }

        private static void ValidateExamFields(Exam exam)
        {
            if (IsInvalid(exam.ExamName))
            {
                throw new InvalidExamException(
                    parameterName: nameof(Exam.ExamName),
                    parameterValue: exam.ExamName);
            }

            if (IsInvalid(exam.CorrectAnswers))
            {
                throw new InvalidExamException(
                    parameterName: nameof(Exam.CorrectAnswers),
                    parameterValue: exam.CorrectAnswers);
            }

            if (IsInvalid(exam.TestKey))
            {
                throw new InvalidExamException(
                    parameterName: nameof(Exam.TestKey),
                    parameterValue: exam.TestKey);
            }

            if (exam.QuestionCount <= 0 || exam.QuestionCount > 100)
            {
                throw new InvalidExamException(
                    parameterName: nameof(Exam.QuestionCount),
                    parameterValue: exam.QuestionCount);
            }

            if (exam.CreatedByTeacherId == default)
            {
                throw new InvalidExamException(
                    parameterName: nameof(Exam.CreatedByTeacherId),
                    parameterValue: exam.CreatedByTeacherId);
            }
        }

        private static void ValidateExamIdIsNull(Guid examId)
        {
            if (examId == default)
            {
                throw new InvalidExamException(
                    parameterName: nameof(Exam.ExamId),
                    parameterValue: examId);
            }
        }

        private static void ValidateExamIsNull(Exam exam)
        {
            if (exam is null)
            {
                throw new NullExamException();
            }
        }

        private static bool IsInvalid(string input) => String.IsNullOrWhiteSpace(input);
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

