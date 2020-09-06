using ScrapySharp.Extensions;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
	public class ScrapeService
	{
		private readonly ScrapingBrowser _browser;

		private const string cvOnlineUrl = "https://www.cvonline.lt/darbo-skelbimai/informacines-technologijos";
		private const int max = 20;
		private const int updateLimit = 2;


		public ScrapeService()
		{
			_browser = new ScrapingBrowser();
		}

		public void ScrapeCvOnelineUrls()
		{
			for (int i = 0; i < max; i++)
			{
				WebPage homePage = _browser.NavigateToPage(new Uri($"{cvOnlineUrl}?page={i}"));

				var nodes = homePage.Html.CssSelect("div.cvo_module_offer");

				var test = "test";
			}
		}
	}
}
