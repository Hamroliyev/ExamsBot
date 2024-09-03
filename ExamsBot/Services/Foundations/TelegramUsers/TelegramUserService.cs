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

        public async ValueTask<TelegramUser> InsertTelegramUserAsync(TelegramUser telegramUser) =>
            await this.storageBroker.InsertTelegramUserAsync(telegramUser);

        public IQueryable<TelegramUser> RetriveAllTelegramUsers() => 
            this.storageBroker.SelectAllTelegramUsers();


        public async ValueTask<TelegramUser> RetriveTelegramUserByIdAsync(Guid telegramUserId) =>
            await this.storageBroker.SelectTelegramUserByIdAsync(telegramUserId);

        public async ValueTask<TelegramUser> UpdateTelegramUserAsync(TelegramUser telegramUser) =>
            await this.storageBroker.UpdateTelegramUserAsync(telegramUser);
    }
}
