using System.Net.Mail;

namespace RazorPagesPD011.Models;

public interface IEmailSender
{
    public Task Send(string senderEmail, string title, string body, string recipient,
        CancellationToken cancellationToken);
}

