    // Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Models.TelegramUsers;
using ExamsBot.Services.Foundations.TelegramUsers;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ExamsBot.Services.Processings.Telegrams
{
    public class TelegramUserProcessingService : ITelegramUserProcessingService
    {
        private readonly ITelegramUserService telegramUserService;

        public TelegramUserProcessingService(ITelegramUserService telegramUserService)
        {
            this.telegramUserService = telegramUserService;
        }

        public async ValueTask<TelegramUser> ModifyTelegramUserAsync(TelegramUser telegramUser) =>
            await this.telegramUserService.ModifyTelegramUserAsync(telegramUser);

        public async ValueTask<TelegramUser> UpsertTelegramUserProcessingService(
            TelegramUser telegramUser)
        {
            TelegramUser maybeTelegramUser =
                await this.telegramUserService.RetriveAllTelegramUsers()
                    .FirstOrDefaultAsync(user => user.TelegramId == telegramUser.TelegramId);

            return maybeTelegramUser is null
                ? await this.telegramUserService.AddTelegramUserAsync(telegramUser)
                : maybeTelegramUser;
        }
    }
}
