using MailsSender.Core.Helpers;
using MailsSender.Core.Services;
using NUnit.Framework;

namespace MailsSender.Core.Tests.Services
{
    [TestFixture]
    public class MarkdownToHtmlConverterTests
    {
        #region Infrastructure

        private string GetResourceAsString(string resourceName)
        {
            var resourcePath = $"Services.MarkdownToHtml.{resourceName}";
            return EmbeddedResourcesReader.GetAsUtf8String(resourcePath);
        }

        private void AssertHtmlEquals(string actual, string expected)
        {
            actual = CrlfToLf(actual);
            expected = CrlfToLf(expected);
            Assert.That(actual, Is.EqualTo(expected));
        }

        private string CrlfToLf(string source)
        {
            var result = source.Replace("\r\n", "\n");
            return result;
        }

        #endregion

        [Test]
        public void CanConvertToHtml()
        {
            var list = EmbeddedResourcesReader.GetList();
            var source = GetResourceAsString("MarkdownToHtml-01-Source.md");
            var expected = GetResourceAsString("MarkdownToHtml-01-Dest.html");

            var actual = MarkdownToHtmlConverter.ToHtml(source);

            AssertHtmlEquals(actual, expected);
        }

        [Test]
        public void CanConvertToHtml_WithEmoticons()
        {
            var list = EmbeddedResourcesReader.GetList();
            var source = GetResourceAsString("MarkdownToHtml-Emoticons-Source.md");
            var expected = GetResourceAsString("MarkdownToHtml-Emoticons-Dest.html");

            var actual = MarkdownToHtmlConverter.ToHtml(source);

            AssertHtmlEquals(actual, expected);
        }
    }
}
