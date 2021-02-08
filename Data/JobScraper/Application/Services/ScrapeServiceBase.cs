using Application.Interfaces;
using Domain.Configuration;
using ScrapySharp.Extensions;
using System;
using System.Linq;
using System.Threading;

namespace Application.Services
{
    public class ScrapeServiceBase
    {
        private readonly IScraper _scraper;
        private IScrapeConfiguration _scrapeSettings;

        public ScrapeServiceBase(IScraper scraper, IScrapeConfiguration scrapeSettings)
        {
            _scraper = scraper ?? throw new ArgumentNullException(nameof(scraper));
            _scrapeSettings = scrapeSettings ?? throw new ArgumentNullException(nameof(scrapeSettings));
        }

        public string ScrapeInfo(string url)
        {
            //Sleep
            Thread.Sleep(1);

            var node = _scraper.GetHtml(url);
            var html = node.CssSelect(_scrapeSettings.Info);
            if (html.Any())
            {
                return html.First().InnerHtml;
            }

            return "";
        }

        public byte[] ScrapeLogo(string url)
        {
            return _scraper.GetImage(url);
        }
    }
}
