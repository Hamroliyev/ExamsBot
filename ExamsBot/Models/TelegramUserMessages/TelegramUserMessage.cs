// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Models.TelegramUsers;
using System;
using Telegram.Bot.Types;

namespace ExamsBot.Models.TelegramUserMessages
{
    public class TelegramUserMessage
    {
        public Guid Id { get; set; }
        public TelegramUser TelegramUser { get; set; }
        public Message Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public TelegramUserMessageType MessageType { get; set; }
        public bool IsProcessed { get; set; }
        public string ProcessingStatus { get; set; }
    }

    public enum TelegramUserMessageType
    {
        Text,
        Command,
        Contact,
        Location,
        Document,
        Photo,
        Unknown
    }
}