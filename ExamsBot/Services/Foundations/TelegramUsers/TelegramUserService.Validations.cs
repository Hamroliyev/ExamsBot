// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using ExamsBot.Models.TelegramUsers;
using ExamsBot.Models.TelegramUsers.Exceptions;

namespace ExamsBot.Services.Foundations.TelegramUsers
{
    public partial class TelegramUserService
    {
        private void ValidateTelegramUserOnCreate(TelegramUser telegramUser)
        {
            ValidateTelegramUserIsNull(telegramUser);
            ValidateTelegramUserIdIsNull(telegramUser.Id);
            ValidateTelegramUserFields(telegramUser);
            ValidateInvalidAuditFields(telegramUser);
            ValidateAuditFieldsDataOnCreate(telegramUser);
            ValidateCreatedDateIsRecent(telegramUser);
        }

        private void ValidateTelegramUserOnModify(TelegramUser telegramUser)
        {
            ValidateTelegramUserIsNull(telegramUser);
            ValidateTelegramUserIdIsNull(telegramUser.Id);
            ValidateTelegramUserFields(telegramUser);
            ValidateInvalidAuditFields(telegramUser);
            ValidateAuditFieldsOnModify(telegramUser);
        }

        private static void ValidateStorageTelegramUser(TelegramUser storageTelegramUser, Guid telegramUserId)
        {
            if (storageTelegramUser is null)
            {
                throw new NotFoundTelegramUserException(telegramUserId);
            }
        }

        private static void ValidateStorageTelegramUserByTelegramId(TelegramUser storageTelegramUser, long telegramId)
        {
            if (storageTelegramUser is null)
            {
                throw new NotFoundTelegramUserException(Guid.Empty);
            }
        }

        private void ValidateCreatedDateIsRecent(TelegramUser telegramUser)
        {
            if (IsDateNotRecent(telegramUser.CreatedAt))
            {
                throw new InvalidTelegramUserException(
                    parameterName: nameof(TelegramUser.CreatedAt),
                    parameterValue: telegramUser.CreatedAt);
            }
        }

        private static void ValidateAuditFieldsDataOnCreate(TelegramUser telegramUser)
        {
            switch (telegramUser)
            {
                case { } when telegramUser.UpdatedAt.HasValue && telegramUser.UpdatedAt != telegramUser.CreatedAt:
                    throw new InvalidTelegramUserException(
                    parameterName: nameof(TelegramUser.UpdatedAt),
                    parameterValue: telegramUser.UpdatedAt);
            }
        }

        private static void ValidateInvalidAuditFields(TelegramUser telegramUser)
        {
            switch (telegramUser)
            {
                case { } when IsInvalid(telegramUser.CreatedAt):
                    throw new InvalidTelegramUserException(
                    parameterName: nameof(TelegramUser.CreatedAt),
                    parameterValue: telegramUser.CreatedAt);
            }
        }

        private void ValidateAuditFieldsOnModify(TelegramUser telegramUser)
        {
            switch (telegramUser)
            {
                case { } when !telegramUser.UpdatedAt.HasValue:
                    throw new InvalidTelegramUserException(
                        parameterName: nameof(TelegramUser.UpdatedAt),
                        parameterValue: telegramUser.UpdatedAt);

                case { } when telegramUser.UpdatedAt.HasValue && IsDateNotRecent(telegramUser.UpdatedAt.Value):
                    throw new InvalidTelegramUserException(
                        parameterName: nameof(TelegramUser.UpdatedAt),
                        parameterValue: telegramUser.UpdatedAt);
            }
        }

        private static void ValidateAgainstStorageTelegramUserOnModify(TelegramUser inputTelegramUser, TelegramUser storageTelegramUser)
        {
            switch (inputTelegramUser)
            {
                case { } when inputTelegramUser.CreatedAt != storageTelegramUser.CreatedAt:
                    throw new InvalidTelegramUserException(
                        parameterName: nameof(TelegramUser.CreatedAt),
                        parameterValue: inputTelegramUser.CreatedAt);

                case { } when inputTelegramUser.UpdatedAt == storageTelegramUser.UpdatedAt:
                    throw new InvalidTelegramUserException(
                        parameterName: nameof(TelegramUser.UpdatedAt),
                        parameterValue: inputTelegramUser.UpdatedAt);
            }
        }

        private static void ValidateTelegramUserFields(TelegramUser telegramUser)
        {
            if (IsInvalid(telegramUser.FirstName))
            {
                throw new InvalidTelegramUserException(
                    parameterName: nameof(TelegramUser.FirstName),
                    parameterValue: telegramUser.FirstName);
            }

            if (telegramUser.TelegramId <= 0)
            {
                throw new InvalidTelegramUserException(
                    parameterName: nameof(TelegramUser.TelegramId),
                    parameterValue: telegramUser.TelegramId);
            }
        }

        private static void ValidateTelegramId(long telegramId)
        {
            if (telegramId <= 0)
            {
                throw new InvalidTelegramUserException(
                    parameterName: nameof(TelegramUser.TelegramId),
                    parameterValue: telegramId);
            }
        }

        private static void ValidateTelegramUserIdIsNull(Guid telegramUserId)
        {
            if (telegramUserId == default)
            {
                throw new InvalidTelegramUserException(
                    parameterName: nameof(TelegramUser.Id),
                    parameterValue: telegramUserId);
            }
        }

        private static void ValidateTelegramUserIsNull(TelegramUser telegramUser)
        {
            if (telegramUser is null)
            {
                throw new NullTelegramUserException();
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

