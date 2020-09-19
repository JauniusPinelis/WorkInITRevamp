using Application.Configuration;
using Application.Helpers;
using Application.Interfaces;
using Domain.Models;
using ScrapySharp.Extensions;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Application
{
	public class CvOnlineScrapeService : IScrapeService
	{
		private readonly IScraper _scraper;

		private IScrapeConfiguration _scrapeSettings;

		private const string cvOnlineUrl = "https://www.cvonline.lt/darbo-skelbimai/informacines-technologijos";

		private const int delay = 1000; //in ms

		public CvOnlineScrapeService(IScraper scraper, CvOnlineConfiguration configuration)
		{
			_scraper = scraper;

			_scrapeSettings = configuration;
		}

		public string ScrapeInfo(string url)
		{
			var node = _scraper.GetHtml(url);
			var html = node.CssSelect(_scrapeSettings.Info);
			if (html.Any())
			{
				return html.First().InnerText;
			}

			return "";
		}

		public IEnumerable<JobUrl> ScrapeUrls()
		{
			return ScrapeUrls(2);
		}

		public IEnumerable<JobUrl> ScrapeUrls(int pageLimit)
		{
			var jobUrls = new List<CvOnlineJob>();
			for (int i = 0; i < pageLimit; i++)
			{
				//Sleep
				Thread.Sleep(delay);

				var html = _scraper.GetHtml($"{cvOnlineUrl}?page={i}");

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
						var jobUrl = new CvOnlineJob();

						var infoNode = nameResult.First();

						jobUrl.Title = infoNode.InnerText;
						jobUrl.Url = UrlHelpers.ProcessUrl(infoNode.Attributes["href"].Value);
						jobUrl.Salary = Selectors.SelectName(node,_scrapeSettings.Salary);
						jobUrl.Company = Selectors.SelectCompany(node, _scrapeSettings.Company);

						jobUrls.Add(jobUrl);
					}
				}

			}

			return jobUrls;
		}

	}
}
