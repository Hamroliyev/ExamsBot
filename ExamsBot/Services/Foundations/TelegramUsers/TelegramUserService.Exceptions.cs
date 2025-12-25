// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EFxceptions.Models.Exceptions;
using ExamsBot.Models.TelegramUsers;
using ExamsBot.Models.TelegramUsers.Exceptions;
using Xeptions;

namespace ExamsBot.Services.Foundations.TelegramUsers
{
    public partial class TelegramUserService
    {
        private delegate ValueTask<TelegramUser> ReturningTelegramUserFunction();
        private delegate IQueryable<TelegramUser> ReturningQueryableTelegramUserFunction();

        private async ValueTask<TelegramUser> TryCatch(ReturningTelegramUserFunction returningTelegramUserFunction)
        {
            try
            {
                return await returningTelegramUserFunction();
            }
            catch (NullTelegramUserException nullTelegramUserException)
            {
                throw CreateAndLogValidationException(nullTelegramUserException);
            }
            catch (InvalidTelegramUserException invalidTelegramUserException)
            {
                throw CreateAndLogValidationException(invalidTelegramUserException);
            }
            catch (NotFoundTelegramUserException notFoundTelegramUserException)
            {
                throw CreateAndLogValidationException(notFoundTelegramUserException);
            }
            catch (DuplicateKeyException duplicateKeyException)
            {
                var alreadyExistsTelegramUserException =
                    new AlreadyExistsTelegramUserException(duplicateKeyException);

                throw CreateAndLogValidationException(alreadyExistsTelegramUserException);
            }
            catch (SqlException sqlException)
            {
                var failedTelegramUserStorageException =
                    new FailedTelegramUserStorageException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedTelegramUserStorageException);
            }
            catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
            {
                var lockedTelegramUserException =
                    new LockedTelegramUserException(dbUpdateConcurrencyException);

                throw CreateAndLogDependencyException(lockedTelegramUserException);
            }
            catch (DbUpdateException dbUpdateException)
            {
                var failedTelegramUserStorageException =
                    new FailedTelegramUserStorageException(dbUpdateException);

                throw CreateAndLogDependencyException(failedTelegramUserStorageException);
            }
            catch (Exception exception)
            {
                var failedTelegramUserServiceException =
                    new FailedTelegramUserServiceException(exception);

                throw CreateAndLogServiceException(failedTelegramUserServiceException);
            }
        }

        private IQueryable<TelegramUser> TryCatch(ReturningQueryableTelegramUserFunction returningQueryableTelegramUserFunction)
        {
            try
            {
                return returningQueryableTelegramUserFunction();
            }
            catch (SqlException sqlException)
            {
                var failedTelegramUserStorageException =
                    new FailedTelegramUserStorageException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedTelegramUserStorageException);
            }
            catch (Exception exception)
            {
                var failedTelegramUserServiceException =
                    new FailedTelegramUserServiceException(exception);

                throw CreateAndLogServiceException(failedTelegramUserServiceException);
            }
        }

        private Exception CreateAndLogValidationException(Exception exception)
        {
            var telegramUserValidationException = new TelegramUserValidationException(exception);
            this.loggingBroker.LogError(telegramUserValidationException);

            return telegramUserValidationException;
        }

        private TelegramUserDependencyException CreateAndLogDependencyException(Exception exception)
        {
            var telegramUserDependencyException = new TelegramUserDependencyException(exception);
            this.loggingBroker.LogError(telegramUserDependencyException);

            return telegramUserDependencyException;
        }

        private TelegramUserDependencyException CreateAndLogCriticalDependencyException(Xeption exception)
        {
            var telegramUserDependencyException = new TelegramUserDependencyException(exception);
            this.loggingBroker.LogCritical(telegramUserDependencyException);

            return telegramUserDependencyException;
        }

        private TelegramUserServiceException CreateAndLogServiceException(Exception exception)
        {
            var telegramUserServiceException = new TelegramUserServiceException(exception);
            this.loggingBroker.LogError(telegramUserServiceException);

            return telegramUserServiceException;
        }
    }
}

