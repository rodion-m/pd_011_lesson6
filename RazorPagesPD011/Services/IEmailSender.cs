namespace RazorPagesPD011.Services;

public interface IEmailSender
{
    public Task Send(string senderEmail, string title, string body, string recipient,
        CancellationToken cancellationToken);
}

