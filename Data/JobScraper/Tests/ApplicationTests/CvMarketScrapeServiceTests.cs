using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApplicationTests
{
    public class CvMarketScrapeServiceTests : TestBase
    {
		[Fact]
		public void GetHtml_GivenMockData_IsNotEmpty()
		{
			var html = _cvMarketScraper.GetHtml("");

			html.Should().NotBe(String.Empty);
		}

		[Fact]
		public void ScrapeUrl_GivenMockData_ResultsAreNotEmpty()
		{
			var urls = _cvMarketScrapeService.ScrapeUrls();

			urls.Should().NotBeEmpty();
		}

		[Fact]
		public void ScrapeUrl_GivenMockData_GetsLogoUrl()
		{
			var urls = _cvMarketScrapeService.ScrapeUrls();

			urls.Should().NotBeEmpty();
			urls.First().Logourl.Should().NotBeNullOrEmpty();
		}
	}
}
