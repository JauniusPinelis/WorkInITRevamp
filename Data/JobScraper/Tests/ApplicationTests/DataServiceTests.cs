using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApplicationTests
{
    public class DataServiceTests : TestBase
    {

        [Fact]
        public void ScrapeCvOnlineUrls_GivenMockData_DbHasCvOnlineJobs()
		{
            _dataService.ScrapeJobs();

            var urls = _unitOfWork.CvOnline.GetAll();

            urls.Where(u => u.PortalName == "CvOnline").Should().NotBeEmpty();
		}

        [Fact]
        public void ScrapeCvBankasUrls_GivenMockData_DbHasCvBankasJobs()
        {
            _dataService.ScrapeJobs();

            var urls = _unitOfWork.CvBankas.GetAll();

            urls.Where(u => u.PortalName == "CvBankas").Should().NotBeEmpty();
        }

        [Fact]
        public void ScrapeCvMarketUrls_GivenMockData_DbHasCvMarketJobs()
		{
            _dataService.ScrapeJobs();
            var urls = _unitOfWork.CvMarket.GetAll();

            urls.Where(u => u.PortalName == "CvMarket").Should().NotBeEmpty();
        }

        [Fact]
        public void ProcessCompanies_GivenMockData_DbContainsCompanies()
		{
            _dataService.ScrapeJobs();
            _dataService.ProcessCompanies();
            

            var companies = _companyService.GetAll().ToList();

            companies.Should().NotBeEmpty();
		}

  //      [Fact]
  //      public void ProcessLogos_GivenMockData_CompanieshaveLogos()
		//{
  //          _dataService.ScrapeJobs();
  //          _dataService.ProcessCompanies();
  //          _dataService.ProcessCompanyLogos();

  //          var companies = _companyService.GetAll().ToList();
  //          companies.Select(c => c.ImageData).Where(i => i != null).Should().NotBeEmpty();


		//}
    }
}
