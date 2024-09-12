// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Models.TelegramUsers;
using System.Threading.Tasks;

namespace ExamsBot.Services.Processings.Telegrams
{
    public interface ITelegramUserProcessingService
    {
        ValueTask<TelegramUser> ModifyTelegramUserAsync(TelegramUser telegramUser);
        ValueTask<TelegramUser> UpsertTelegramUserProcessingService(TelegramUser telegramUser);
    }
}
