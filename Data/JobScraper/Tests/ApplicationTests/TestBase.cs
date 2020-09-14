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
		protected readonly IScraper _scraper;
		protected readonly CvBankasScrapeService _cvBankasScrapeService;
		protected readonly CvOnlineScrapeService _cvOnlineScrapeService;
		protected readonly DataService _dataService;
		protected readonly JobUrlRepository _jobUrlRepository;

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

			_cvOnlineScrapeService = new CvOnlineScrapeService(_scraper, new CvOnlineConfiguration());
			_cvBankasScrapeService = new CvBankasScrapeService(_scraper, new CvBankasConfiguration());

			var options = new DbContextOptionsBuilder<DataContext>()
			.UseInMemoryDatabase("TestDb")
			.Options;

			var context = new DataContext(options);

			_jobUrlRepository = new JobUrlRepository(context);

			_dataService = new DataService(_jobUrlRepository, _cvOnlineScrapeService, _cvBankasScrapeService);

		}
    }
}
