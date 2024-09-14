// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Models.TelegramUserMessages;
using ExamsBot.Models.TelegramUsers;
using System.Threading.Tasks;
using System;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using ExamsBot.Brokers.Telegrams;

namespace ExamsBot.Services.Foundations.Telegrams
{
    public class TelegramService : ITelegramService
    {
        private readonly ITelegramBroker telegramBroker;

        public TelegramService(ITelegramBroker telegramBroker)
        {
            this.telegramBroker = telegramBroker;
        }

        public void RegisterTelegramEventHandler(
            Func<TelegramUserMessage, ValueTask> eventHandler)
        {
            this.telegramBroker.RegisterTelegramEventHandler(async message =>
                await ProcessTelegramTaskAsync(message, eventHandler));
        }

        private async ValueTask ProcessTelegramTaskAsync(
            Update update, 
            Func<TelegramUserMessage, ValueTask> eventHandler)
        {
            if (update.Type == UpdateType.Message)
            {
                var telegramUser = new TelegramUser
                {
                    Id = Guid.NewGuid(),
                    TelegramId = update.Message.From.Id,
                    FirstName = update.Message.From.FirstName, 
                    Status = TelegramUserStatus.Student
                };

                var telegramUserMessage = new TelegramUserMessage
                {
                    TelegramUser = telegramUser,
                    Message = update.Message
                };

                await eventHandler(telegramUserMessage);
            }
        }

        public async ValueTask<Message> SendMessageAsync(
            long userTelegramId,
            string message,
            int? replyToMessageId = null,
            ParseMode? parseMode = null,
            IReplyMarkup replyMarkup = null)
        {
            return await this.telegramBroker.SendTextMessageAsync(
                    userTelegramId: userTelegramId,
                    message: message,
                    replyToMessageId: replyToMessageId,
                    parseMode: parseMode,
                    replyMarkup: replyMarkup);

        }

        public async ValueTask DeleteMessageAsync(
            long userTelegramId,
            int messageId)
        {
            await this.telegramBroker.DeleteMessageAsync(
               userTelegramId: userTelegramId,
               messageId: messageId);
        }
    }
}

