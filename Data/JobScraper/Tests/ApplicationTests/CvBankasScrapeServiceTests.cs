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

		[Fact]
		public void GetHtml_GivenMockData_IsNotEmpty()
		{
			var html = _cvBankasScraper.GetHtml("");

			html.Should().NotBe(String.Empty);
		}

		[Fact]
		public void ScrapeUrl_GivenMockData_ResultsAreNotEmpty()
		{
			var urls = _cvBankasScrapeService.ScrapeUrls();

			urls.Should().NotBeEmpty();
		}

		[Fact]
		public void ScrapeUrl_GivenMockData_GetsCompanyName()
		{
			var urls = _cvBankasScrapeService.ScrapeUrls();

			urls.Should().NotBeEmpty();
			urls.First().Company.Should().NotBeNullOrEmpty();
		}

		[Fact]
		public void ScrapeUrl_GivenMockData_GetsSalary()
		{
			var urls = _cvBankasScrapeService.ScrapeUrls();

			urls.Should().NotBeEmpty();
			urls.First().Salary.Should().NotBeNullOrEmpty();
		}
	}
}
