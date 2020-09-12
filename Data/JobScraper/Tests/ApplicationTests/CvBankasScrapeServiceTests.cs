using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApplicationTests
{
    public class CvBankasScrapeServiceTests : TestBase
    {
		public CvBankasScrapeServiceTests() : base("\\Data\\CvBankas.txt", "CvBankas")
		{

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
	}
}
