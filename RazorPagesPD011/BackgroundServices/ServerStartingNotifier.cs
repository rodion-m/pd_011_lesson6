using RazorPagesPD011.Models;
using RazorPagesPD011.Services;

namespace RazorPagesPD011.BackgroundServices;

//class - Деталь! (а если sealed, то деталь 100%)
//interface - Абстракция!

public sealed class ServerStartingNotifier : BackgroundService
{
    private readonly IEmailSender _emailSender;
    private readonly ILogger<ServerStartingNotifier> _logger;

    public ServerStartingNotifier(
        IEmailSender emailSender,
        ILogger<ServerStartingNotifier> logger)
    {
        _emailSender = emailSender;
        _logger = logger;
        _logger.LogDebug(nameof(ServerStartingNotifier));
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Сервер запущен");
        const int attemptsLimit = 3;
        var currentAttempt = 0;
        bool mailSent = false;
        do
        {
            currentAttempt++;
            try
            {
                var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
                await _emailSender.Send(
                    "asp2022_5@rodion-m.ru",
                    "Сервер работает",
                    "Сервер работает",
                    "rodion@outlook.com",
                    cts.Token);
                mailSent = true;
                _logger.LogInformation("Письмо успешно отправлено");
            }
            catch (Exception e) when (currentAttempt < attemptsLimit)
            {
                _logger.LogWarning(e, "Ошибка отправки Email при попытке № {Attempt}", currentAttempt);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Ошибка отправки Email при попытке № {Attempt}", currentAttempt);
            }
        } while (!mailSent && currentAttempt < attemptsLimit);
    }


    public async Task SendNotificationEverySecond()
    {
        while (true)
        {
            try
            {
                var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
                await _emailSender.Send(
                    "asp2022_5@rodion-m.ru",
                    "Сервер работает",
                    "Сервер работает",
                    "rodion@outlook.com",
                    cts.Token);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Ошибка при попытке отправить Email");
            }

            await Task.Delay(TimeSpan.FromSeconds(5));
        }
    }
}