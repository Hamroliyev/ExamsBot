// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Models.TelegramUserMessages;
using System.Threading.Tasks;

namespace ExamsBot.Services.Orchestrations.Telegrams
{
    public interface ITelegramUserOrchestrationService
    {
        ValueTask<TelegramUserMessage> ProcessTelegramUserAsync(
            TelegramUserMessage telegramUserMessage);
        void ListenTelegramUserMessage();
    }
}
