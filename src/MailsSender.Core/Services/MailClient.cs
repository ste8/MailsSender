using System.Net.Mail;
using System.Net;
using MailsSender.Core.Entities;

namespace MailsSender.Core.Services
{
    public class MailClient : IDisposable
    {
        private SmtpClient? _smtpClient;

        protected MailClient(MailServerSettings settings)
        {
            _smtpClient = CreateSmtpClient(settings);
        }

        public static MailClient Init(MailServerSettings settings)
        {
            return new MailClient(settings);
        }

        private void AssertIsInitialized()
        {
            if (_smtpClient == null) {
                throw new Exception($"{nameof(MailClient)} is not initialized.");
            }
        }

        private SmtpClient CreateSmtpClient(MailServerSettings settings)
        {
            var smptClient = new SmtpClient {
                Host = settings.SmtpServer,
                Port = settings.Port,
                EnableSsl = settings.EnableSsl
            };
            if (!string.IsNullOrWhiteSpace(settings.Username)) {
                smptClient.UseDefaultCredentials = false;
                smptClient.Credentials = new NetworkCredential(settings.Username, settings.Password);
            }

            return smptClient;
        }

        public void Send(MailInfo mailInfo)
        {
            AssertIsInitialized();

            var mailMessage = CreateMailMessage(mailInfo);
            _smtpClient!.Send(mailMessage);
        }

        private MailMessage CreateMailMessage(MailInfo mailInfo)
        {
            var from = new MailAddress(mailInfo.Sender.MailAddress, mailInfo.Sender.Name);
            var recipient = new MailAddress(mailInfo.Recipient.MailAddress);
            var message = new MailMessage(from, recipient) {
                Subject = mailInfo.Subject,
                Body = mailInfo.BodyAsHtml,
                IsBodyHtml = true
            };

            AddAttachments(mailInfo, message);
            return message;
        }

        private static void AddAttachments(MailInfo mailInfo, MailMessage message)
        {
            if (mailInfo.Attachments == null) return;

            foreach (var sourceAttachment in mailInfo.Attachments) {
                var attachment = new Attachment(sourceAttachment.FilePath, sourceAttachment.MediaType);
                attachment.Name = sourceAttachment.FileName;
                message.Attachments.Add(attachment);
            }
        }


        public void Dispose()
        {
            if (_smtpClient != null) {
                _smtpClient.Dispose();
                _smtpClient = null;
            }
        }
    }
}
