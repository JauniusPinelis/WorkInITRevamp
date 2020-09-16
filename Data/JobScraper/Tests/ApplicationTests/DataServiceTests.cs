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
            _dataService.ScrapeCvOnlineUrls();

            var urls = _jobUrlRepository.GetAll();

            urls.Where(u => u.PortalName == "CvOnline").Should().NotBeEmpty();
		}

        [Fact]
        public void ScrapeCvBankasUrls_GivenMockData_DbHasCvBankasJobs()
        {
            _dataService.ScrapeCvBankasUrls();

            var urls = _jobUrlRepository.GetAll();

            urls.Where(u => u.PortalName == "CvBankas").Should().NotBeEmpty();
        }

        [Fact]
        public void ScrapeCvMarketUrls_GivenMockData_DbHasCvMarketJobs()
		{
            _dataService.ScrapeCvMarketUrls();
            var urls = _jobUrlRepository.GetAll();

            urls.Where(u => u.PortalName == "CvMarket").Should().NotBeEmpty();
        }
    }
}
