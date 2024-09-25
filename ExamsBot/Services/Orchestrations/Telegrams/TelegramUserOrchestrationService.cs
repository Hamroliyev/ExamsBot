// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Models.TelegramUserMessages;
using ExamsBot.Services.Foundations.Exams;
using ExamsBot.Services.Foundations.Telegrams;
using ExamsBot.Services.Foundations.TelegramUsers;
using ExamsBot.Services.Processings.Exams;
using ExamsBot.Services.Processings.Telegrams;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace ExamsBot.Services.Orchestrations.Telegrams
{
    public partial class TelegramUserOrchestrationService : ITelegramUserOrchestrationService
    {
        private readonly ITelegramUserProcessingService telegramUserProcessingService;
        private readonly ITelegramService telegramService;
        private readonly ITelegramUserService telegramUserService;
        private readonly IExamProcessingService examProcessingService;
        private readonly IExamService examService;

        private const string startCommand = "/start";
        private const string speakCommand = "Speak...";
        private const string connectWithUseCommand = "ℹ️ Biz bilan bog'lanish";
        private const string feedbackCommand = "✍️ Fikringizni qoldiring";

        public TelegramUserOrchestrationService(
            ITelegramUserProcessingService telegramUserProcessingService,
            ITelegramService telegramService,
            ITelegramUserService telegramUserService,
            IExamProcessingService examProcessingService,
            IExamService examService)
        {
            this.telegramUserProcessingService = telegramUserProcessingService;
            this.telegramService = telegramService;
            this.telegramUserService = telegramUserService;
            this.examProcessingService = examProcessingService;
            this.examService = examService;
        }

        public async ValueTask<TelegramUserMessage> ProcessTelegramUserAsync(
            TelegramUserMessage telegramUserMessage)
        {
            telegramUserMessage.TelegramUser =
                await telegramUserProcessingService
                    .UpsertTelegramUserProcessingService(telegramUserMessage.TelegramUser);

            if (await StartAsync(telegramUserMessage))
                return telegramUserMessage;

            if (await RegisterAsync(telegramUserMessage))
                return telegramUserMessage;

            if (await ConnectWithUsAsync(telegramUserMessage))
                return telegramUserMessage;

            if (await TestAsync(telegramUserMessage))
                return telegramUserMessage;

            if (await FeedbackAsync(telegramUserMessage))
                return telegramUserMessage;

            return telegramUserMessage;
        }

        public void ListenTelegramUserMessage()
        {
            this.telegramService.RegisterTelegramEventHandler(async (telegramUserMessage) =>
            {
                await this.ProcessTelegramUserAsync(telegramUserMessage);
            });
        }

        private static ReplyKeyboardMarkup MainMarkupEng()
        {
            return new ReplyKeyboardMarkup(new KeyboardButton[][]
            {
                new KeyboardButton[]{new KeyboardButton("Speak...")},
                new KeyboardButton[]
                {
                    new KeyboardButton("✍️ Fikringizni qoldiring"),
                    new KeyboardButton("ℹ️ Biz bilan bog'lanish")
                },
            })
            {
                ResizeKeyboard = true
            };
        }
    }
}
