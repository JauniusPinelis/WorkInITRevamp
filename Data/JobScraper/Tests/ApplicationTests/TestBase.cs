using Application;
using Application.Configuration;
using Application.Interfaces;
using Application.Services;
using HtmlAgilityPack;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
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
		protected readonly IScraper _cvBankasScraper;
		protected readonly IScraper _cvOnlineScraper;
		protected readonly IScraper _cvMarketScraper;

		protected readonly CvBankasScrapeService _cvBankasScrapeService;
		protected readonly CvOnlineScrapeService _cvOnlineScrapeService;
		protected readonly CvMarketScrapeService _cvMarketScrapeService;

		protected readonly DataService _dataService;
		protected readonly JobUrlRepository _jobUrlRepository;

		private const string cvOnlineFilePath = "\\Data\\CvOnline.txt";
		private const string cvBankasFilePath = "\\Data\\CvBankas.txt";
		private const string CvMarketFilePath = "\\Data\\CvMarket.txt";

		public TestBase()
		{

			_cvOnlineScraper = SetupMockScraper(cvOnlineFilePath);
			_cvBankasScraper = SetupMockScraper(cvBankasFilePath);
			_cvMarketScraper = SetupMockScraper(CvMarketFilePath);


			_cvOnlineScrapeService = new CvOnlineScrapeService(_cvOnlineScraper, new CvOnlineConfiguration());
			_cvBankasScrapeService = new CvBankasScrapeService(_cvBankasScraper, new CvBankasConfiguration());
			_cvMarketScrapeService = new CvMarketScrapeService(_cvMarketScraper, new CvMarketConfiguration());

			var options = new DbContextOptionsBuilder<DataContext>()
			.UseInMemoryDatabase("TestDb")
			.Options;

			var context = new DataContext(options);

			_jobUrlRepository = new JobUrlRepository(context);

			_dataService = new DataService(_jobUrlRepository, _cvOnlineScrapeService, _cvBankasScrapeService,
				_cvMarketScrapeService
				);


		}

		private IScraper SetupMockScraper(string filePath)
		{
			var scraperMock = new Mock<IScraper>();

			var path = Directory.GetCurrentDirectory() + filePath;

			var decodedData = WebUtility.HtmlDecode(File.ReadAllText(path));

			HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml(decodedData);
			HtmlNodeCollection nodes = doc.DocumentNode.ChildNodes;

			scraperMock.Setup(s => s.GetHtml(It.IsAny<string>())).Returns(nodes.First());

			return scraperMock.Object;
		}
    }
}
