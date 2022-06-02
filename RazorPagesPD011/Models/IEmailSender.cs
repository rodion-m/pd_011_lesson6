namespace RazorPagesPD011.Models;

public interface IEmailSender
{
    void Send(string senderEmail, string title, string body, string recipient);
}