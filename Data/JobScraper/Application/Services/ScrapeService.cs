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
	public class ScrapeService
	{
		private readonly ScrapingBrowser _browser;

		private const string cvOnlineUrl = "https://www.cvonline.lt/darbo-skelbimai/informacines-technologijos";
		
		private const int max = 2;
		private const int updateLimit = 2;
		private const int delay = 1000; //in ms


		public ScrapeService()
		{
			_browser = new ScrapingBrowser();
		}

		public IEnumerable<JobUrl> ScrapeCvOnelineUrls()
		{
			var jobUrls = new List<JobUrl>();
			for (int i = 0; i < max; i++)
			{
				//Sleep
				Thread.Sleep(delay);

				WebPage homePage = _browser.NavigateToPage(new Uri($"{cvOnlineUrl}?page={i}"));

				var nodes = homePage.Html.CssSelect("div.cvo_module_offer");

				if (!nodes.Any())
				{
					// finished last page - stop scraping
					break;
				}

				foreach (var node in nodes)
				{
					
					var nameResult = node.CssSelect("a[itemprop=title]");
					if (nameResult.Any())
					{
						var jobUrl = new JobUrl();

						var infoNode = nameResult.First();

						jobUrl.Title = infoNode.InnerText;
						jobUrl.Url = infoNode.Attributes["href"].Value;

						var salaryNode = node.CssSelect("span.salary-blue");
						if (salaryNode.Any())
						{
							var salaryInfo = salaryNode.First();
							jobUrl.Salary = salaryInfo.InnerText;
						}
						jobUrls.Add(jobUrl);
					}
				}
				
			}

			return jobUrls;
		}

	}
}
