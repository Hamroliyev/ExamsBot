// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System.Threading.Tasks;
using System;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;

namespace ExamsBot.Brokers.Telegrams
{
    public interface ITelegramBroker
    {
        void RegisterTelegramEventHandler(Func<Update, ValueTask> eventHandler);

        ValueTask<Message> SendTextMessageAsync(long userTelegramId,
           string message,
           int? replyToMessageId = null,
           ParseMode? parseMode = null,
           IReplyMarkup replyMarkup = null);
        ValueTask DeleteMessageAsync(
            long userTelegramId,
            int messageId);
    }
}
