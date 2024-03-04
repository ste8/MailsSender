using Markdig;

namespace MailsSender.Core.Services
{
    public class MarkdownToHtmlConverter
    {
        public static string ToHtml(string markdown)
        {
            var html = Markdown.ToHtml(markdown);
            html = RemoveEndingNewLineChar(html);
            return html;
        }

        private static string RemoveEndingNewLineChar(string html)
        {
            if (html.EndsWith("\n")) {
                html = html.Substring(0, html.Length - 1);
            }
            return html;
        }
    }
}
