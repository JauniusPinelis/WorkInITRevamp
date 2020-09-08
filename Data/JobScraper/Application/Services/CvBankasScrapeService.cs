using Application.Helpers;
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
		private readonly ScrapingBrowser _browser;

		private const string url = "https://www.cvbankas.lt/?padalinys%5B0%5D=76&page";

		private const int max = 2;
		private const int delay = 1000; //in ms


		public CvBankasScrapeService()
		{
			_browser = new ScrapingBrowser();
			_browser.Encoding = Encoding.UTF8;
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

				WebPage homePage = _browser.NavigateToPage(new Uri($"{url}?page={i}"));

				var nodes = homePage.Html.CssSelect("a.list_a");

				if (!nodes.Any())
				{
					// finished last page - stop scraping
					break;
				}

				foreach (var node in nodes)
				{

					var nameResult = node.CssSelect("h3.list_h3");
					if (nameResult.Any())
					{
						var nameInfoNode = nameResult.First();
						var jobUrl = new JobUrl();


						jobUrl.Title = nameInfoNode.InnerText;
						jobUrl.Url = node.Attributes["href"].Value;
						//jobUrl.Salary = Selectors.SelectName(node);
						//jobUrl.Company = Selectors.SelectCompany(node);

						jobUrls.Add(jobUrl);
					}


				}

			}

			return jobUrls;
		}
	}
}
