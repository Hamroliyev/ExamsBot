// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Models.TelegramUserMessages;
using ExamsBot.Models.TelegramUsers;
using System.Threading.Tasks;
using System.Timers;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace ExamsBot.Services.Orchestrations.Telegrams
{
    public partial class TelegramUserOrchestrationService
    {
        private async ValueTask<bool> TestAsync(TelegramUserMessage telegramUserMessage)
        {
            if (telegramUserMessage.Message.Text == speakCommand)
            {
                var markup = TestMarkup();

                WebAppInfo url = new WebAppInfo()
                {
                    Url = "https://elsaspeak.com/en/ai/?variant=B"
                };

                await this.telegramService.SendMessageAsync(
                    userTelegramId: telegramUserMessage.TelegramUser.TelegramId,
                    message: "Penguin Education 📝\n\n Speaking qilamiz.",
                    parseMode: ParseMode.Html,
                    replyMarkup: (InlineKeyboardMarkup)InlineKeyboardButton.WithWebApp("Launch Mini-Speak-App", url));

                return true;
            }
            else if (telegramUserMessage.TelegramUser.Status == TelegramUserStatus.Teacher)
            {
                await SendTestAcceptanceMessage(telegramUserMessage);

                return true;
            }

            return false;
        }
        private async ValueTask SendTestAcceptanceMessage(TelegramUserMessage telegramUserMessage)
        {
            await this.telegramService.SendMessageAsync(
                    userTelegramId: 949459770,
                    @$"Penguin Education 🌚\n\nSiz habar qabul qilib oldingiz
                    @{telegramUserMessage.Message.Chat.Username} dan\n\n Habar:\n{telegramUserMessage.Message.Text}");


            Timer timer = new Timer(30000);
            timer.Elapsed += async (sender, e) =>
            {
                await this.telegramService.SendMessageAsync(
                   userTelegramId: telegramUserMessage.TelegramUser.TelegramId,
                   "Penguin Education administration 😎\n\nBizga habaringiz yetib keldi, Katta raxmat.");

                timer.Stop();
            };

            timer.Start();
        }

        private static ReplyKeyboardMarkup TestMarkup()
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
