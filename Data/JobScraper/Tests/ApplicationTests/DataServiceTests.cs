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
    }
}
