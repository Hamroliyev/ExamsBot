// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Models.TelegramUsers;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace ExamsBot.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<TelegramUser> TelegramUsers { get; set; }

        public async ValueTask<TelegramUser> InsertTelegramUserAsync(TelegramUser telegramUser) =>
            await InsertAsync(telegramUser);

        public IQueryable<TelegramUser> SelectAllTelegramUsers() =>
            SelectAll<TelegramUser>();

        public async ValueTask<TelegramUser> SelectTelegramUserByIdAsync(Guid telegramUserId) =>
            await SelectAsync<TelegramUser>(telegramUserId);

        public async ValueTask<TelegramUser> UpdateTelegramUserAsync(TelegramUser telegramUser) =>
            await UpdateAsync(telegramUser);

        public async ValueTask<TelegramUser> DeleteTelegramUserAsync(TelegramUser telegramUser) =>
            await DeleteAsync(telegramUser);
    }
}
