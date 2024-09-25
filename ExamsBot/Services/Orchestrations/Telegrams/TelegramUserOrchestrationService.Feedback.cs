// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Models.TelegramUserMessages;
using ExamsBot.Models.TelegramUsers;
using System.Threading.Tasks;
using System.Timers;
using Telegram.Bot.Types.ReplyMarkups;

namespace ExamsBot.Services.Orchestrations.Telegrams
{
    public partial class TelegramUserOrchestrationService
    {
        private async ValueTask<bool> FeedbackAsync(TelegramUserMessage telegramUserMessage)
        {
            if (telegramUserMessage.Message.Text == feedbackCommand)
            {
                var markup = FeedbackMarkupEng();

                await this.telegramService.SendMessageAsync(
                    userTelegramId: telegramUserMessage.TelegramUser.TelegramId,
                    message: "Penguin Education 📝\n\nMy dear friend, leave your feedback as a message.",
                    replyMarkup: markup);

                return true;
            }
            else if (telegramUserMessage.TelegramUser.Status == TelegramUserStatus.Teacher)
            {
                await SendfeedbackAcceptanceMessage(telegramUserMessage);

                return true;
            }

            return false;
        }

        private async ValueTask SendfeedbackAcceptanceMessage(TelegramUserMessage telegramUserMessage)
        {
            await this.telegramService.SendMessageAsync(
                    userTelegramId: 949459770,
                    $"Penguin Education 🌚\n\nYou have a recieved a review from @{telegramUserMessage.Message.Chat.Username}\n\nFeedback:\n{telegramUserMessage.Message.Text}");

            await this.telegramService.SendMessageAsync(
               userTelegramId: telegramUserMessage.TelegramUser.TelegramId,
               "Penguin Education 🌚\n\nYour review has been accepted😁");

            Timer timer = new Timer(30000);
            timer.Elapsed += async (sender, e) =>
            {

                await this.telegramService.SendMessageAsync(
                   userTelegramId: telegramUserMessage.TelegramUser.TelegramId,
                   "Penguin Education administration 😎\n\nWe thank you for your feedback, have a nice day.");

                timer.Stop();
            };

            timer.Start();
        }

        private static ReplyKeyboardMarkup FeedbackMarkupEng()
        {
            return new ReplyKeyboardMarkup(new KeyboardButton[][]
            {
                new KeyboardButton[]
                {
                    new KeyboardButton("⬅️Menu")
                },
            })
            {
                ResizeKeyboard = true
            };
        }
    }
}
