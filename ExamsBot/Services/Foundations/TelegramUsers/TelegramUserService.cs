// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Brokers.DateTimes;
using ExamsBot.Brokers.Loggings;
using ExamsBot.Brokers.Storages;
using System;
using System.Linq;
using System.Threading.Tasks;
using ExamsBot.Models.TelegramUsers;

namespace ExamsBot.Services.Foundations.TelegramUsers
{
    public partial class TelegramUserService : ITelegramUserService
    {
        private readonly IStorageBroker storageBroker;
        private readonly IDateTimeBroker dateTimeBroker;
        private readonly ILoggingBroker loggingBroker;

        public TelegramUserService(
            IStorageBroker storageBroker,
            IDateTimeBroker dateTimeBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.dateTimeBroker = dateTimeBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<TelegramUser> AddTelegramUserAsync(TelegramUser telegramUser) =>
            TryCatch(async () =>
            {
                ValidateTelegramUserOnCreate(telegramUser);

                return await this.storageBroker.InsertTelegramUserAsync(telegramUser);
            });

        public IQueryable<TelegramUser> RetrieveAllTelegramUsers() =>
            TryCatch(() => this.storageBroker.SelectAllTelegramUsers());

        public ValueTask<TelegramUser> RetrieveTelegramUserByIdAsync(Guid telegramUserId) =>
            TryCatch(async () =>
            {
                ValidateTelegramUserIdIsNull(telegramUserId);
                TelegramUser storageTelegramUser = await this.storageBroker.SelectTelegramUserByIdAsync(telegramUserId);
                ValidateStorageTelegramUser(storageTelegramUser, telegramUserId);

                return storageTelegramUser;
            });

        public ValueTask<TelegramUser> RetrieveTelegramUserByTelegramIdAsync(long telegramId) =>
            TryCatch(async () =>
            {
                ValidateTelegramId(telegramId);
                TelegramUser storageTelegramUser = await this.storageBroker
                    .SelectTelegramUsersByTelegramId(telegramId)
                    .Where(user => user.TelegramId == telegramId)
                    .FirstOrDefaultAsync();
                ValidateStorageTelegramUserByTelegramId(storageTelegramUser, telegramId);

                return storageTelegramUser;
            });

        public ValueTask<TelegramUser> ModifyTelegramUserAsync(TelegramUser telegramUser) =>
            TryCatch(async () =>
            {
                ValidateTelegramUserOnModify(telegramUser);
                TelegramUser maybeTelegramUser = await this.storageBroker.SelectTelegramUserByIdAsync(telegramUser.Id);
                ValidateStorageTelegramUser(maybeTelegramUser, telegramUser.Id);
                ValidateAgainstStorageTelegramUserOnModify(inputTelegramUser: telegramUser, storageTelegramUser: maybeTelegramUser);

                return await this.storageBroker.UpdateTelegramUserAsync(telegramUser);
            });

        public ValueTask<TelegramUser> RemoveTelegramUserAsync(TelegramUser telegramUser) =>
            TryCatch(async () =>
            {
                ValidateTelegramUserIsNull(telegramUser);
                ValidateTelegramUserIdIsNull(telegramUser.Id);
                TelegramUser maybeTelegramUser = await this.storageBroker.SelectTelegramUserByIdAsync(telegramUser.Id);
                ValidateStorageTelegramUser(maybeTelegramUser, telegramUser.Id);

                return await this.storageBroker.DeleteTelegramUserAsync(maybeTelegramUser);
            });
    }
}
