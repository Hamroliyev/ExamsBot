﻿// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Models.TelegramUserMessages;
using System.Threading.Tasks;
using System;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;

namespace ExamsBot.Services.Foundations.Telegrams
{
    public interface ITelegramService
    {
        void RegisterTelegramEventHandler(Func<TelegramUserMessage, ValueTask> eventHandler);
        ValueTask<Message> SendMessageAsync(long userTelegramId,
           string message,
           int? replyToMessageId = null,
           ParseMode? parseMode = null,
           IReplyMarkup replyMarkup = null);

        ValueTask DeleteMessageAsync(
            long userTelegramId,
            int messageId);
    }
}
