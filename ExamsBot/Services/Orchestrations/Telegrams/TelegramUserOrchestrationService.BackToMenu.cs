// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Models.TelegramUserMessages;
using System.Threading.Tasks;

namespace ExamsBot.Services.Orchestrations.Telegrams
{
    public partial class TelegramUserOrchestrationService
    {
        public async ValueTask<bool> BackToMenu(TelegramUserMessage telegramUserMessage)
        {
            if (telegramUserMessage.Message.Text == startCommand)
            {
                var markup = MainMarkupEng();
                string message = "Penguin Education 👀\n\nMenu mening do'stim 👇🏼";

                await this.telegramService.SendMessageAsync(
                    userTelegramId: telegramUserMessage.TelegramUser.TelegramId,
                    message: message,
                    replyMarkup: markup);

                return true;
            }

            return false;
        }
    }
}
