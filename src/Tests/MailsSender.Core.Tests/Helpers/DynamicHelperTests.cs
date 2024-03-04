using MailsSender.Core.Helpers;
using NUnit.Framework;

namespace MailsSender.Core.Tests.Helpers
{
    [TestFixture]
    public class DynamicHelperTests
    {
        [Test]
        public void CanConvertDictionaryToDynamic()
        {
            var dict = new Dictionary<string, string> {
                { "Name", "Pluto" },
                { "Mail", "pluto@gmail.com" },
            };

            var model = DynamicHelper.ToDynamic(dict);

            Assert.That(model.Name.ToString(), Is.EqualTo("Pluto"));
            Assert.That(model.Mail.ToString(), Is.EqualTo("pluto@gmail.com"));
        }
    }
}
