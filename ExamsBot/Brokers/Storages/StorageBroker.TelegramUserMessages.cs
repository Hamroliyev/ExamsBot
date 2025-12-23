// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ExamsBot.Models.TelegramUserMessages;

namespace ExamsBot.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<TelegramUserMessage> TelegramUserMessages { get; set; }
        public async ValueTask<TelegramUserMessage> InsertTelegramUserMessageAsync(TelegramUserMessage telegramUserMessage) =>
            await InsertAsync(telegramUserMessage);
        public IQueryable<TelegramUserMessage> SelectAllTelegramUserMessages() =>
            SelectAll<TelegramUserMessage>();
        public async ValueTask<TelegramUserMessage> SelectTelegramUserMessageByIdAsync(Guid id) =>
            await SelectAsync<TelegramUserMessage>(id);
        public async ValueTask<TelegramUserMessage> UpdateTelegramUserMessageAsync(TelegramUserMessage telegramUserMessage) =>
            await UpdateAsync(telegramUserMessage);
        public async ValueTask<TelegramUserMessage> DeleteTelegramUserMessageAsync(TelegramUserMessage telegramUserMessage) =>
            await DeleteAsync(telegramUserMessage);
    }
}
