using MailsSender.Core.Helpers;
using MailsSender.Core.Services;
using NUnit.Framework;

namespace MailsSender.Core.Tests.Services
{
    [TestFixture]
    public class RecipientsDataExcelReaderTests
    {
        private string GetExcelFilePath(string fileName)
        {
            var filePath = PathHelper.GetAbsolutePath($"Services\\ExcelRecipients\\{fileName}");
            return filePath;
        }

        [Test]
        public void CanRead()
        {
            var filePath = GetExcelFilePath("ExcelRecipients-01.xlsx");
            var reader = new RecipientsDataExcelReader();
            var actual =reader.Read(filePath);

            Assert.That(actual.Count, Is.EqualTo(3));

            var recipient = actual[0];
            Assert.That(recipient.FirstName.ToString(), Is.EqualTo("Giuseppe"));
            Assert.That(recipient.LastName.ToString(), Is.EqualTo("Verdi"));
            Assert.That(recipient.Mail.ToString(), Is.EqualTo("giuseppe@verdi.com"));
            Assert.That(recipient.Title.ToString(), Is.EqualTo("Hello Giuseppe!"));

            recipient = actual[2];
            Assert.That(recipient.FirstName.ToString(), Is.EqualTo("John"));
            Assert.That(recipient.LastName.ToString(), Is.EqualTo("Doe"));
            Assert.That(recipient.Mail.ToString(), Is.EqualTo("john@doe.com"));
            Assert.That(recipient.Title.ToString(), Is.EqualTo("Heyyyy!"));
        }
    }
}
