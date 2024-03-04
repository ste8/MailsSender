namespace MailsSender.Core.Entities;

public class MailServerSettings
{
    public string SmtpServer { get; set; } = string.Empty;
    public string? Username { get; set; }
    public string? Password { get; set; }
    public bool EnableSsl { get; set; }
    public int Port { get; set; }
}