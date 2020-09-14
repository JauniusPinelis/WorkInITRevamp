using Application;
using Application.Configuration;
using Application.Interfaces;
using Application.Services;
using HtmlAgilityPack;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTests
{
    public abstract class TestBase
    {
		protected readonly IScraper _scraper;
		protected readonly IScrapeService _scrapeService;

		public TestBase(string filePath, string name)
		{
			var scraperMock = new Mock<IScraper>();

			var path = Directory.GetCurrentDirectory() + filePath;

			var decodedData = WebUtility.HtmlDecode(File.ReadAllText(path));

			HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml(decodedData);
			HtmlNodeCollection nodes = doc.DocumentNode.ChildNodes;

			scraperMock.Setup(s => s.GetHtml(It.IsAny<string>())).Returns(nodes.First());

			_scraper = scraperMock.Object;

			if (name == "CvBankas")
			{
				_scrapeService = new CvBankasScrapeService(_scraper, new CvBankasConfiguration());
			}
			else
			{
				_scrapeService = new CvOnlineScrapeService(_scraper, new CvOnlineConfiguration());
			}
		
		}
    }
}
