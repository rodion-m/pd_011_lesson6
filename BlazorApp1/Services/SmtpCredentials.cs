namespace BlazorApp1.Services;

public class SmtpCredentials
{
    public string? UserName { get; set; } = "asds@gmail.com";
    public string? Password { get; set; }
    public string? Host { get; set; }
    public int Port { get; set; }
}