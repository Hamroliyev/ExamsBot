// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Brokers.Storages;
using ExamsBot.Models.TelegramUsers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ExamsBot.Services.Foundations.TelegramUsers
{
    public class TelegramUserService : ITelegramUserService
    {
        private readonly IStorageBroker storageBroker;

        public TelegramUserService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public async ValueTask<TelegramUser> DeleteTelegramUserAsync(TelegramUser telegramUser) =>
            await this.storageBroker.DeleteTelegramUserAsync(telegramUser);

        public async ValueTask<TelegramUser> AddTelegramUserAsync(TelegramUser telegramUser) =>
            await this.storageBroker.InsertTelegramUserAsync(telegramUser);

        public IQueryable<TelegramUser> RetrieveAllTelegramUsers() =>
            this.storageBroker.SelectAllTelegramUsers();

        public async ValueTask<TelegramUser> RetrieveTelegramUserByIdAsync(Guid telegramUserId) =>
            await this.storageBroker.SelectTelegramUserByIdAsync(telegramUserId);

        public async ValueTask<TelegramUser> ModifyTelegramUserAsync(TelegramUser telegramUser) =>
            await this.storageBroker.UpdateTelegramUserAsync(telegramUser);

        public async ValueTask<TelegramUser> RetrieveTelegramUserByTelegramIdAsync(long telegramId) =>
            await this.storageBroker.SelectTelegramUserByTelegramIdAsync(telegramId);

        public async ValueTask<TelegramUser> RemoveTelegramUserAsync(TelegramUser telegramUser) =>
            await this.DeleteTelegramUserAsync(telegramUser);
    }
}
