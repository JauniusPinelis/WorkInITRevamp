using Application.Dtos;
using Application.Helpers;
using Application.Interfaces;
using Application.Services;
using Domain.Configuration;
using Domain.Helpers;
using ScrapySharp.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Application
{
	public class CvOnlineScrapeService : ScrapeServiceBase, IScrapeService
	{
		private readonly IScraper _scraper;

		private IScrapeConfiguration _scrapeSettings;

		private const string cvOnlineUrl = "https://www.cvonline.lt/darbo-skelbimai/informacines-technologijos";

		private const int delay = 1000; //in ms

		public CvOnlineScrapeService(IScraper scraper, CvOnlineConfiguration configuration) : base(scraper)
		{
			_scraper = scraper;

			_scrapeSettings = configuration;
		}

		public IEnumerable<JobDto> ScrapeUrls()
		{
			return ScrapeUrls(2);
		}

		public IEnumerable<JobDto> ScrapeUrls(int pageLimit)
		{
			var jobUrls = new List<JobDto>();
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
						var jobUrl = new JobDto();

						var infoNode = nameResult.First();

						jobUrl.Name = infoNode.InnerText;
						jobUrl.Url = UrlHelpers.ProcessUrl(infoNode.Attributes["href"].Value);
						jobUrl.Salary = Selectors.SelectName(node, _scrapeSettings.Salary);
						jobUrl.CompanyName = Selectors.SelectCompany(node, _scrapeSettings.Company);
						jobUrl.Logourl = Selectors.SelectLogoUrl(node, _scrapeSettings.LogoUrl);

						jobUrls.Add(jobUrl);
					}
				}

			}

			return jobUrls;
		}

	}
}
