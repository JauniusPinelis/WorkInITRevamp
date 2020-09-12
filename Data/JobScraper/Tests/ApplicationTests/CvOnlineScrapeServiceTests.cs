using Application;
using Application.Interfaces;
using FluentAssertions;
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApplicationTests
{
    public class CvOnlineScrapeServiceTests
    {
		private readonly IScraper _scraper;
		private readonly CvOnlineScrapeService _scrapeService;

		public CvOnlineScrapeServiceTests()
		{
			var scraperMock = new Mock<IScraper>();

			var path = Directory.GetCurrentDirectory() + "\\Data\\CvOnline.txt";

			var decodedData = WebUtility.HtmlDecode(File.ReadAllText(path));

			HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml(decodedData);
			HtmlNodeCollection nodes = doc.DocumentNode.ChildNodes;

			scraperMock.Setup(s => s.GetHtml(It.IsAny<string>())).Returns(nodes.First());

			_scraper = scraperMock.Object;

			_scrapeService = new CvOnlineScrapeService(_scraper);


		}

		[Fact]
		public void GetHtml_GivenMockData_IsNotEmpty()
		{
			var html = _scraper.GetHtml("");

			html.Should().NotBe(String.Empty);
		}

		[Fact]
		public void ScrapeUrl_GivenMockData_ResultsAreNotEmpty()
		{
			var urls = _scrapeService.ScrapeUrls();

			urls.Should().NotBeEmpty();
		}

		[Fact]
		public void ScrapeUrl_GivenMockData_GetsCompanyName()
		{
			var urls = _scrapeService.ScrapeUrls();

			urls.Should().NotBeEmpty();
			urls.First().Company.Should().NotBeNullOrEmpty();
		}

		[Fact]
		public void ScrapeUrl_GivenMockData_GetsSalary()
		{
			var urls = _scrapeService.ScrapeUrls();

			urls.Should().NotBeEmpty();
			urls.First().Salary.Should().NotBeNullOrEmpty();
		}
	}
}
