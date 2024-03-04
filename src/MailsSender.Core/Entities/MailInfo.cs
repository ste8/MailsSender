namespace MailsSender.Core.Entities;

public record MailInfo(
    MailSender Sender,
    MailRecipient Recipient,
    string Subject,
    string BodyAsHtml,
    MailAttachment[]? Attachments = null);

public record MailRecipient(string MailAddress);

public record MailSender(string Name, string MailAddress);

public record MailAttachment(string FilePath, string FileName, string MediaType);