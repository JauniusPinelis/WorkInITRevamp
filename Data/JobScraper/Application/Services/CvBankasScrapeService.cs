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
using System.Threading.Tasks;

namespace Application.Services
{
	public class CvBankasScrapeService : IScrapeService
	{
		private readonly IScraper _scraper;

		private const string url = "https://www.cvbankas.lt/?padalinys%5B0%5D=76&page";

		private const int max = 2;
		private const int delay = 1000; //in ms

		private ScrapeSettings _scrapeSettings;


		public CvBankasScrapeService(IScraper scraper)
		{
			_scraper = scraper;

			_scrapeSettings = new ScrapeSettings()
			{
				Posting = "article",
				Name = "h3.list_h3",
				Company = "span.dib mt5",
				Salary = "salary_amount"
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

				var html = _scraper.GetHtml($"{url}?page={i}");

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
						var jobUrl = new JobUrl();


						jobUrl.Title = nameInfoNode.InnerText;
						jobUrl.Url = node.Attributes["href"].Value;
						jobUrl.Salary = Selectors.SelectName(node, "");
						jobUrl.Company = Selectors.SelectCompany(node, "");

						jobUrls.Add(jobUrl);
					}


				}

			}

			return jobUrls;
		}
	}
}
