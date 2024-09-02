// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Models.TelegramUsers;
using Telegram.Bot.Types;

namespace ExamsBot.Models.TelegramUserMessages
{
    public class TelegramUserMessage
    {
        public TelegramUser TelegramUser { get; set; }
        public Message Message { get; set; }
    }
}
