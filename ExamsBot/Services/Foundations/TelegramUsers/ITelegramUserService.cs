// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Models.TelegramUsers;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace ExamsBot.Services.Foundations.TelegramUsers
{
    public interface ITelegramUserService
    {
        ValueTask<TelegramUser> AddTelegramUserAsync(TelegramUser telegramUser);
        IQueryable<TelegramUser> RetrieveAllTelegramUsers();
        ValueTask<TelegramUser> RetrieveTelegramUserByIdAsync(Guid id);
        ValueTask<TelegramUser> RetrieveTelegramUserByTelegramIdAsync(long telegramId);
        ValueTask<TelegramUser> ModifyTelegramUserAsync(TelegramUser telegramUser);
        ValueTask<TelegramUser> RemoveTelegramUserAsync(TelegramUser telegramUser);
    }
}
