// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Models.TelegramUserMessages;
using ExamsBot.Models.TelegramUsers;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace ExamsBot.Services.Orchestrations.Telegrams
{
    public partial class TelegramUserOrchestrationService
    {
        private async ValueTask<bool> RegisterAsync(TelegramUserMessage telegramUserMessage)
        {
            if (string.IsNullOrWhiteSpace(telegramUserMessage.TelegramUser.PhoneNumber))
            {
                if (telegramUserMessage.Message.Type == MessageType.Contact &&
                    telegramUserMessage.TelegramUser.TelegramId == telegramUserMessage.Message.Contact.UserId)
                {
                    string phoneNumber = telegramUserMessage.Message.Contact.PhoneNumber;
                    telegramUserMessage.TelegramUser.PhoneNumber = phoneNumber;
                    telegramUserMessage.TelegramUser.Status = TelegramUserStatus.Teacher;

                    await this.telegramUserProcessingService
                        .ModifyTelegramUserAsync(telegramUserMessage.TelegramUser);

                    await telegramService.SendMessageAsync(
                        userTelegramId: telegramUserMessage.TelegramUser.TelegramId,
                        message: "Iltimos ism familiyangizni jo'nating?");

                    return true;
                }

                return false;
            }

            if (string.IsNullOrWhiteSpace(telegramUserMessage.TelegramUser.FirstName))
            {
                if (telegramUserMessage.Message.Type == MessageType.Text &&
                    telegramUserMessage.TelegramUser.TelegramId == telegramUserMessage.Message.From.Id)
                {
                    string firstName = telegramUserMessage.Message.Text;
                    telegramUserMessage.TelegramUser.FirstName = firstName;

                    await this.telegramUserProcessingService
                        .ModifyTelegramUserAsync(telegramUserMessage.TelegramUser);

                    var markup = MainMarkupEng();

                    WebAppInfo url = new WebAppInfo()
                    {
                        Url = "https://elsaspeak.com/en/ai/?variant=B"
                    };

                    await this.telegramService.SendMessageAsync(
                        userTelegramId: telegramUserMessage.TelegramUser.TelegramId,
                        message: "Penguin Education 📝\n\nQani o'zbekiston kelajagi, fikringizni qoldiring.",
                        parseMode: ParseMode.Html,
                        replyMarkup: (InlineKeyboardMarkup)InlineKeyboardButton.WithWebApp("Launch Mini-App", url));

                    await this.telegramService.SendMessageAsync(
                        userTelegramId: telegramUserMessage.TelegramUser.TelegramId,
                        message: $"Penguin Education 👻\n\nThank you for registering {telegramUserMessage.TelegramUser.FirstName}, use it for good!",
                        replyMarkup: markup);

                    return true;
                }

                return false;
            }
            
            return false;
        }
    }
}

