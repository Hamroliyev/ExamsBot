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
        ValueTask<TelegramUser> InsertTelegramUserAsync(TelegramUser telegramUser);
        IQueryable<TelegramUser> RetriveAllTelegramUsers();
        ValueTask<TelegramUser> RetriveTelegramUserByIdAsync(Guid telegramUserId);
        ValueTask<TelegramUser> UpdateTelegramUserAsync(TelegramUser telegramUser);
        ValueTask<TelegramUser> DeleteTelegramUserAsync(TelegramUser telegramUser);
    }
}
