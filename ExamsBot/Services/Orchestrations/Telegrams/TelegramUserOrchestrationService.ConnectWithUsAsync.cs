// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Models.TelegramUserMessages;
using System.Threading.Tasks;

namespace ExamsBot.Services.Orchestrations.Telegrams
{
    public partial class TelegramUserOrchestrationService
    {
        private async ValueTask<bool> ConnectWithUsAsync(TelegramUserMessage telegramUserMessage)
        {
            if (telegramUserMessage.Message.Text == connectWithUseCommand)
            {
                await this.telegramService.SendMessageAsync(
                    userTelegramId: telegramUserMessage.TelegramUser.TelegramId,
                    message: "Penguin education ⚡️\n\nHere are our contacts my dear friend: @Hamroliyev_19");

                return true;
            }

            return false;
        }
    }
}
