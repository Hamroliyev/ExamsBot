// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace ExamsBot.Brokers.Telegrams
{
    public class TelegramBroker : ITelegramBroker
    {
        private readonly ITelegramBotClient telegramBotClient;
        private readonly IConfiguration configuration;
        private Func<Update, ValueTask> eventHandler;

        public TelegramBroker(IConfiguration configuration)
        {
            this.configuration = configuration;
            string token = this.configuration["BotConfiguration:BotToken"]
                ?? throw new InvalidOperationException(
                    "Bot token is not configured in BotConfiguration:BotToken");

            this.telegramBotClient = new TelegramBotClient(token);
            this.InitializeReceiver();
        }

        public void RegisterTelegramEventHandler(Func<Update, ValueTask> eventHandler) =>
            this.eventHandler = eventHandler ?? throw new ArgumentNullException(nameof(eventHandler));

        public async ValueTask<Message> SendTextMessageAsync(
            long userTelegramId,
            string message,
            int? replyToMessageId = null,
            ParseMode? parseMode = null,
            IReplyMarkup replyMarkup = null)
        {
            ValidateMessage(message);

            return await this.telegramBotClient.SendTextMessageAsync(
                chatId: userTelegramId,
                text: message,
                parseMode: parseMode,
                replyToMessageId: replyToMessageId,
                replyMarkup: replyMarkup);
        }

        public async ValueTask DeleteMessageAsync(
            long userTelegramId,
            int messageId)
        {
            ValidateTelegramId(userTelegramId);
            ValidateMessageId(messageId);

            await this.telegramBotClient.DeleteMessageAsync(
                chatId: userTelegramId,
                messageId: messageId);
        }

        private void InitializeReceiver()
        {
            ReceiverOptions receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = Array.Empty<UpdateType>(), // Receive all update types
                ThrowPendingUpdates = true // Drop pending updates on bot restart
            };

            this.telegramBotClient.StartReceiving(
                updateHandler: HandleUpdateAsync,
                pollingErrorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: default);
        }

        private async Task HandleUpdateAsync(
            ITelegramBotClient botClient,
            Update update,
            CancellationToken cancellationToken)
        {
            if (this.eventHandler is not null)
            {
                await this.eventHandler(update);
            }
        }

        private static Task HandlePollingErrorAsync(
            ITelegramBotClient botClient,
            Exception exception,
            CancellationToken cancellationToken)
        {
            // Let exception bubble up - do not catch or handle
            // Exception handling should be in service layer
            return Task.FromException(exception);
        }

        private static void ValidateMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException(
                    "Message cannot be null or whitespace.",
                    nameof(message));

            if (message.Length > 4096)
                throw new ArgumentException(
                    "Message exceeds Telegram's 4096 character limit.",
                    nameof(message));
        }

        private static void ValidateTelegramId(long telegramId)
        {
            if (telegramId <= 0)
                throw new ArgumentException(
                    "Telegram ID must be positive.",
                    nameof(telegramId));
        }

        private static void ValidateMessageId(int messageId)
        {
            if (messageId <= 0)
                throw new ArgumentException(
                    "Message ID must be positive.",
                    nameof(messageId));
        }

        private static void LogError(string message) =>
            Console.WriteLine($"[ERROR] {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} - {message}");

        private static void LogWarning(string message) =>
            Console.WriteLine($"[WARNING] {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} - {message}");
    }
}