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

		private ScrapeSettings _scrapeSettings;

		private const string cvOnlineUrl = "https://www.cvonline.lt/darbo-skelbimai/informacines-technologijos";

		private const int max = 2;
		private const int delay = 1000; //in ms


		public CvOnlineScrapeService(IScraper scraper)
		{
			_scraper = scraper;

			_scrapeSettings = new ScrapeSettings()
			{
				Posting = "div.cvo_module_offer",
				Name = "a[itemprop=title]",
				Salary = "span.salary-blue",
				Company = "a[itemprop=name]"
			};

		}

		public IEnumerable<JobUrl> ScrapeUrls()
		{
			return ScrapeUrls(2);
		}

		public IEnumerable<JobUrl> ScrapeUrls(int pageLimit)
		{
			var jobUrls = new List<JobUrl>();
			for (int i = 0; i < pageLimit; i++)
			{
				//Sleep
				Thread.Sleep(delay);

				var html = _scraper.GetHtml($"{cvOnlineUrl}?page={i}");

				var nodes = html.CssSelect("div.cvo_module_offer");

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
						var jobUrl = new JobUrl();

						var infoNode = nameResult.First();

						jobUrl.Title = infoNode.InnerText;
						jobUrl.Url = infoNode.Attributes["href"].Value;
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
