using MailsSender.Core.Entities;
using MailsSender.Core.Services;
using NUnit.Framework;

namespace MailsSender.Core.Tests.Services
{
    [TestFixture]
    public class MailClientTests
    {
        [Test, Explicit]
        public void CanSend_WithoutAttachments()
        {
            var mailServerSettings = CreateMailServerSettings();

            var sender = new MailSender("Giuseppe Verdi", ""); //TODO
            var recipient = new MailRecipient(""); // TODO
            var subject = "Test from MailsSender App";
            var bodyAsHtml = "Body of test mail"
;            var mailInfo = new MailInfo(sender, recipient, subject, bodyAsHtml);

            using var mailClient = MailClient.Init(mailServerSettings);
            mailClient.Send(mailInfo);
        }

        private static MailServerSettings CreateMailServerSettings()
        {
            return new MailServerSettings  {
                SmtpServer = "", //TODO
                Username = "", //TODO
                Password = "", //TODO
                //Port = 587, 
                //EnableSsl = true
            };
        }
    }
}
