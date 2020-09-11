using HtmlAgilityPack;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class Scraper
    {
		private readonly ScrapingBrowser _browser;

		public Scraper()
		{
			_browser = new ScrapingBrowser();
			_browser.Encoding = Encoding.UTF8;
		}

		public HtmlNode GetHtml(string url)
		{
			WebPage homePage = _browser.NavigateToPage(new Uri(url));

			return homePage.Html;
		}
	}
}
