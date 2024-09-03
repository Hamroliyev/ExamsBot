// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Models.TelegramUsers;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace ExamsBot.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<TelegramUser> InsertTelegramUserAsync(TelegramUser telegramUser);
        IQueryable<TelegramUser> SelectAllTelegramUsers();
        ValueTask<TelegramUser> SelectTelegramUserByIdAsync(Guid telegramUserId);
        ValueTask<TelegramUser> UpdateTelegramUserAsync(TelegramUser telegramUser);
        ValueTask<TelegramUser> DeleteTelegramUserAsync(TelegramUser telegramUser);
    }
}
