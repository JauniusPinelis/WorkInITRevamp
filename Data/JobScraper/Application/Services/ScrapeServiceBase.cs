using Application.Interfaces;
using ScrapySharp.Extensions;
using System.Linq;
using System.Threading;

namespace Application.Services
{
	public class ScrapeServiceBase
	{
		private readonly IScraper _scraper;

		public ScrapeServiceBase(IScraper scraper)
		{
			_scraper = scraper;
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
