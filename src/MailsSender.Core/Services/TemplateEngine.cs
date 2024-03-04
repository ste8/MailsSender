using RazorEngine.Configuration;
using RazorEngine.Templating;

namespace MailsSender.Core.Services
{
    public class TemplateEngine
    {
        private readonly IRazorEngineService _service;

        public TemplateEngine()
        {
            var config = new TemplateServiceConfiguration();
            _service = RazorEngineService.Create(config);
        }

        /// <param name="template"></param>
        /// <param name="templateKey"> Used by the library to cache the templates </param>
        /// <param name="model"></param>
        public string Render(string template, string templateKey, object model)
        {
            var rendered = _service.RunCompile(template, templateKey, model: model);
            return rendered;
        }
    }
}
