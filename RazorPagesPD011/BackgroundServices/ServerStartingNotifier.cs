using RazorPagesPD011.Models;

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
        await SendNotificationEverySecond();
        
        // _emailSender.Send(
        //     "asp2022_5@rodion-m.ru",
        //     "Сервер запущен",
        //     "Сервер успешно запущен",
        //     "rodion@outlook.com");
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