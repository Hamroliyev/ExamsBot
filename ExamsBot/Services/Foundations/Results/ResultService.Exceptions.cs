// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EFxceptions.Models.Exceptions;
using ExamsBot.Models.Results;
using ExamsBot.Models.Results.Exceptions;
using Xeptions;

namespace ExamsBot.Services.Foundations.Results
{
    public partial class ResultService
    {
        private delegate ValueTask<Result> ReturningResultFunction();
        private delegate IQueryable<Result> ReturningQueryableResultFunction();

        private async ValueTask<Result> TryCatch(ReturningResultFunction returningResultFunction)
        {
            try
            {
                return await returningResultFunction();
            }
            catch (NullResultException nullResultException)
            {
                throw CreateAndLogValidationException(nullResultException);
            }
            catch (InvalidResultException invalidResultException)
            {
                throw CreateAndLogValidationException(invalidResultException);
            }
            catch (NotFoundResultException notFoundResultException)
            {
                throw CreateAndLogValidationException(notFoundResultException);
            }
            catch (DuplicateKeyException duplicateKeyException)
            {
                var alreadyExistsResultException =
                    new AlreadyExistsResultException(duplicateKeyException);

                throw CreateAndLogValidationException(alreadyExistsResultException);
            }
            catch (SqlException sqlException)
            {
                var failedResultStorageException =
                    new FailedResultStorageException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedResultStorageException);
            }
            catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
            {
                var lockedResultException =
                    new LockedResultException(dbUpdateConcurrencyException);

                throw CreateAndLogDependencyException(lockedResultException);
            }
            catch (DbUpdateException dbUpdateException)
            {
                var failedResultStorageException =
                    new FailedResultStorageException(dbUpdateException);

                throw CreateAndLogDependencyException(failedResultStorageException);
            }
            catch (Exception exception)
            {
                var failedResultServiceException =
                    new FailedResultServiceException(exception);

                throw CreateAndLogServiceException(failedResultServiceException);
            }
        }

        private IQueryable<Result> TryCatch(ReturningQueryableResultFunction returningQueryableResultFunction)
        {
            try
            {
                return returningQueryableResultFunction();
            }
            catch (SqlException sqlException)
            {
                var failedResultStorageException =
                    new FailedResultStorageException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedResultStorageException);
            }
            catch (Exception exception)
            {
                var failedResultServiceException =
                    new FailedResultServiceException(exception);

                throw CreateAndLogServiceException(failedResultServiceException);
            }
        }

        private Exception CreateAndLogValidationException(Exception exception)
        {
            var resultValidationException = new ResultValidationException(exception);
            this.loggingBroker.LogError(resultValidationException);

            return resultValidationException;
        }

        private ResultDependencyException CreateAndLogDependencyException(Exception exception)
        {
            var resultDependencyException = new ResultDependencyException(exception);
            this.loggingBroker.LogError(resultDependencyException);

            return resultDependencyException;
        }

        private ResultDependencyException CreateAndLogCriticalDependencyException(Xeption exception)
        {
            var resultDependencyException = new ResultDependencyException(exception);
            this.loggingBroker.LogCritical(resultDependencyException);

            return resultDependencyException;
        }

        private ResultServiceException CreateAndLogServiceException(Exception exception)
        {
            var resultServiceException = new ResultServiceException(exception);
            this.loggingBroker.LogError(resultServiceException);

            return resultServiceException;
        }
    }
}

