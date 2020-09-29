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
    public class CvOnlineScrapeServiceTests : TestBase
    {

		[Fact]
		public void GetHtml_GivenMockData_IsNotEmpty()
		{
			var html = _cvOnlineScraper.GetHtml("");

			html.Should().NotBe(String.Empty);
		}

		[Fact]
		public void ScrapeUrl_GivenMockData_ResultsAreNotEmpty()
		{
			var urls = _cvOnlineScrapeService.ScrapeUrls();

			urls.Should().NotBeEmpty();
		}

		[Fact]
		public void ScrapeUrl_GivenMockData_GetsCompanyName()
		{
			var urls = _cvOnlineScrapeService.ScrapeUrls();

			urls.Should().NotBeEmpty();
			urls.First().CompanyName.Should().NotBeNullOrEmpty();
		}

		[Fact]
		public void ScrapeUrl_GivenMockData_GetsLogoUrl()
		{
			var urls = _cvOnlineScrapeService.ScrapeUrls();

			urls.Should().NotBeEmpty();
			urls.First().Logourl.Should().NotBeNullOrEmpty();
		}

		[Fact]
		public void ScrapeUrl_GivenMockData_GetsSalary()
		{
			var urls = _cvOnlineScrapeService.ScrapeUrls();

			urls.Should().NotBeEmpty();
			urls.First().Salary.Should().NotBeNullOrEmpty();
		}
	}
}
