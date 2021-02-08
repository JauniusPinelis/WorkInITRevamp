using Application.Dtos;
using Application.Helpers;
using Application.Interfaces;
using Domain.Configuration;
using ScrapySharp.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Application.Services
{
    public class CvBankasScrapeService : ScrapeServiceBase, IScrapeService
    {
        private readonly IScraper _scraper;

        private const string url = "https://www.cvbankas.lt/?padalinys%5B0%5D=76&page";

        private const int max = 2;
        private const int delay = 1000; //in ms

        private IScrapeConfiguration _scrapeSettings;


        public CvBankasScrapeService(IScraper scraper, CvBankasConfiguration cvBankasConfiguration)
            : base(scraper, cvBankasConfiguration)
        {
            _scraper = scraper;
            _scrapeSettings = cvBankasConfiguration;
        }

        public IEnumerable<JobDto> ScrapeUrls()
        {
            return ScrapeUrls(2);
        }

        public IEnumerable<JobDto> ScrapeUrls(int pageLimit)
        {
            var jobUrls = new List<JobDto>();

            for (int i = 0; i < pageLimit; i++)
            {
                //Sleep
                Thread.Sleep(delay);

                var html = _scraper.GetHtml($"{url}?page={i}");

                var nodes = html.CssSelect(_scrapeSettings.Posting);

                if (!nodes.Any())
                {
                    // finished last page - stop scraping
                    break;
                }

                foreach (var node in nodes)
                {

                    var nameResult = node.CssSelect(_scrapeSettings.Name);
                    if (nameResult.Any())
                    {
                        var nameInfoNode = nameResult.First();
                        var jobUrl = new JobDto();

                        jobUrl.Name = nameInfoNode.InnerText;
                        jobUrl.Url = Selectors.SelectUrl(node, _scrapeSettings.Url);
                        jobUrl.Salary = Selectors.SelectName(node, _scrapeSettings.Salary);
                        jobUrl.CompanyName = Selectors.SelectCompany(node, _scrapeSettings.Company);
                        jobUrl.Logourl = Selectors.SelectLogoUrl(node, _scrapeSettings.LogoUrl);

                        jobUrls.Add(jobUrl);
                    }
                }

            }

            return jobUrls;
        }
    }
}
