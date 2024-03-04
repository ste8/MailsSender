using MailsSender.Core.Helpers;
using MailsSender.Core.Services;
using NUnit.Framework;

namespace MailsSender.Core.Tests.Services
{
    [TestFixture]
    public class TemplateEngineTests
    {
        [Test]
        public void Render_SimpleTemplate()
        {
            string template = "Hello @Model.Name, welcome to RazorEngine!";
            string templateKey = "key1";

            var engine = new TemplateEngine();

            var actual = engine.Render(template, templateKey, new { Name = "Mario" });
            Assert.That(actual, Is.EqualTo("Hello Mario, welcome to RazorEngine!"));

            actual = engine.Render(template, templateKey, new { Name = "Giuseppe" });
            Assert.That(actual, Is.EqualTo("Hello Giuseppe, welcome to RazorEngine!"));
        }

        [Test]
        public void Render_UsingDynamicPropertyNames()
        {
            var dict = new Dictionary<string, string> {
                { "Name", "Pluto" },
                { "Mail", "pluto@gmail.com" },
            };

            var model = DynamicHelper.ToDynamic(dict);

            string template = "Hello @Model.Name, welcome to RazorEngine!";
            string templateKey = "key1";

            var engine = new TemplateEngine();

            var actual = engine.Render(template, templateKey, model);
            Assert.That(actual, Is.EqualTo("Hello Pluto, welcome to RazorEngine!"));
        }
    }
}
