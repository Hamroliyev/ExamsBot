// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using ExamsBot.Models.TelegramUserMessages;

namespace ExamsBot.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<TelegramUserMessage> InsertTelegramUserMessageAsync(TelegramUserMessage message);
        IQueryable<TelegramUserMessage> SelectAllTelegramUserMessages();
        ValueTask<TelegramUserMessage> SelectTelegramUserMessageByIdAsync(Guid id);
        ValueTask<TelegramUserMessage> UpdateTelegramUserMessageAsync(TelegramUserMessage message);
        ValueTask<TelegramUserMessage> DeleteTelegramUserMessageAsync(TelegramUserMessage message);
    }
}
