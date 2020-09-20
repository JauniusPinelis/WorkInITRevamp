using Application.Configuration;
using Application.Helpers;
using Application.Interfaces;
using Domain.Models;
using ScrapySharp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services
{
	public class CvMarketScrapeService : IScrapeService
	{
		private const string url = "https://www.cvmarket.lt/informacines-technologijos-darbo-skelbimai";

		private const int delay = 1000; //in ms

		private readonly IScrapeConfiguration _scrapeSettings;
		private readonly IScraper _scraper;

		public CvMarketScrapeService(IScraper scraper, CvMarketConfiguration configuration)
		{
			_scraper = scraper;
			_scrapeSettings = configuration;
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

		public IEnumerable<JobUrl> ScrapeUrls()
		{
			return ScrapeUrls(2);
		}

		public IEnumerable<JobUrl> ScrapeUrls(int pageLimit)
		{
			var jobUrls = new List<CvMarketJob>();

			for (int i = 0; i < pageLimit; i++)
			{
				//Sleep
				Thread.Sleep(delay);

				var html = _scraper.GetHtml($"{url}-{i}");

				var nodes = html.CssSelect(_scrapeSettings.Posting);

				if (!nodes.Any())
				{
					// finished last page - stop scraping
					break;
				}

				foreach (var node in nodes)
				{

					var nameResult = node.CssSelect(_scrapeSettings.Name);
					if (nameResult.Any())
					{
						var nameInfoNode = nameResult.First();
						var jobUrl = new CvMarketJob();

						jobUrl.Title = nameInfoNode.InnerText;
						jobUrl.Url = "https://www.cvmarket.lt/" + Selectors.SelectUrl(node, _scrapeSettings.Url);
						jobUrl.Salary = Selectors.SelectName(node, _scrapeSettings.Salary);
						jobUrl.Company = Selectors.SelectCompany(node, _scrapeSettings.Company);

						jobUrls.Add(jobUrl);
					}
				}

			}

			return jobUrls;
		}
	}
}
