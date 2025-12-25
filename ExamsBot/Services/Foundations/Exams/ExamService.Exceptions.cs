// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EFxceptions.Models.Exceptions;
using ExamsBot.Models.Exams;
using ExamsBot.Models.Exams.Exceptions;
using Xeptions;

namespace ExamsBot.Services.Foundations.Exams
{
    public partial class ExamService
    {
        private delegate ValueTask<Exam> ReturningExamFunction();
        private delegate IQueryable<Exam> ReturningQueryableExamFunction();

        private async ValueTask<Exam> TryCatch(ReturningExamFunction returningExamFunction)
        {
            try
            {
                return await returningExamFunction();
            }
            catch (NullExamException nullExamException)
            {
                throw CreateAndLogValidationException(nullExamException);
            }
            catch (InvalidExamException invalidExamException)
            {
                throw CreateAndLogValidationException(invalidExamException);
            }
            catch (NotFoundExamException notFoundExamException)
            {
                throw CreateAndLogValidationException(notFoundExamException);
            }
            catch (DuplicateKeyException duplicateKeyException)
            {
                var alreadyExistsExamException =
                    new AlreadyExistsExamException(duplicateKeyException);

                throw CreateAndLogValidationException(alreadyExistsExamException);
            }
            catch (SqlException sqlException)
            {
                var failedExamStorageException =
                    new FailedExamStorageException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedExamStorageException);
            }
            catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
            {
                var lockedExamException =
                    new LockedExamException(dbUpdateConcurrencyException);

                throw CreateAndLogDependencyException(lockedExamException);
            }
            catch (DbUpdateException dbUpdateException)
            {
                var failedExamStorageException =
                    new FailedExamStorageException(dbUpdateException);

                throw CreateAndLogDependencyException(failedExamStorageException);
            }
            catch (Exception exception)
            {
                var failedExamServiceException =
                    new FailedExamServiceException(exception);

                throw CreateAndLogServiceException(failedExamServiceException);
            }
        }

        private IQueryable<Exam> TryCatch(ReturningQueryableExamFunction returningQueryableExamFunction)
        {
            try
            {
                return returningQueryableExamFunction();
            }
            catch (SqlException sqlException)
            {
                var failedExamStorageException =
                    new FailedExamStorageException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedExamStorageException);
            }
            catch (Exception exception)
            {
                var failedExamServiceException =
                    new FailedExamServiceException(exception);

                throw CreateAndLogServiceException(failedExamServiceException);
            }
        }

        private Exception CreateAndLogValidationException(Exception exception)
        {
            var examValidationException = new ExamValidationException(exception);
            this.loggingBroker.LogError(examValidationException);

            return examValidationException;
        }

        private ExamDependencyException CreateAndLogDependencyException(Exception exception)
        {
            var examDependencyException = new ExamDependencyException(exception);
            this.loggingBroker.LogError(examDependencyException);

            return examDependencyException;
        }

        private ExamDependencyException CreateAndLogCriticalDependencyException(Xeption exception)
        {
            var examDependencyException = new ExamDependencyException(exception);
            this.loggingBroker.LogCritical(examDependencyException);

            return examDependencyException;
        }

        private ExamServiceException CreateAndLogServiceException(Exception exception)
        {
            var examServiceException = new ExamServiceException(exception);
            this.loggingBroker.LogError(examServiceException);

            return examServiceException;
        }
    }
}

