// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using ExamsBot.Brokers.Storages;
using ExamsBot.Brokers.Telegrams;
using ExamsBot.Services.Foundations.Exams;
using ExamsBot.Services.Foundations.Telegrams;
using ExamsBot.Services.Foundations.TelegramUsers;
using ExamsBot.Services.Orchestrations.Telegrams;
using ExamsBot.Services.Processings.Exams;
using ExamsBot.Services.Processings.Telegrams;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

AddBrokers(builder);
AddFoundationServices(builder);
AddProcessingServices(builder);
AddOrchestrationServices(builder);

var app = builder.Build();
RegisterEventListeners(app);

static void AddBrokers(WebApplicationBuilder builder)
{
    builder.Services.AddTransient<IStorageBroker, StorageBroker>();
    builder.Services.AddSingleton<ITelegramBroker, TelegramBroker>();
}

static void AddFoundationServices(WebApplicationBuilder builder)
{
    builder.Services.AddTransient<ITelegramService, TelegramService>();
    builder.Services.AddTransient<ITelegramUserService, TelegramUserService>();
    builder.Services.AddTransient<IExamService, ExamService>();
}

static void AddProcessingServices(WebApplicationBuilder builder)
{
    builder.Services.AddTransient<ITelegramUserProcessingService, TelegramUserProcessingService>();
    builder.Services.AddTransient<IExamProcessingService, ExamProcessingService>(); 
}
static void AddOrchestrationServices(WebApplicationBuilder builder)
{
    builder.Services.AddTransient<ITelegramUserOrchestrationService, TelegramUserOrchestrationService>();
}

static void RegisterEventListeners(IApplicationBuilder app)
{
    app.ApplicationServices.GetRequiredService<ITelegramUserOrchestrationService>()
                .ListenTelegramUserMessage();
}

app.Run();