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
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApplicationTests
{
    public class CvOnlineScrapeServiceTests
    {
		private readonly IScraper _scraper;

		public CvOnlineScrapeServiceTests()
		{
			var scraperMock = new Mock<IScraper>();

			var path = Directory.GetCurrentDirectory() + "\\Data\\CvOnline.txt";

			var data = File.ReadAllText(path);

			HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml(data);
			HtmlNodeCollection nodes = doc.DocumentNode.ChildNodes;

			scraperMock.Setup(s => s.GetHtml(It.IsAny<string>())).Returns(nodes.First());

			_scraper = scraperMock.Object;
		}

		[Fact]
		public void GetHtml_GivenMockData_IsNotEmpty()
		{
			var html = _scraper.GetHtml("");

			html.Should().NotBe(String.Empty);
		}
    }
}
