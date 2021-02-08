using Application.Services;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;

namespace Application.DataServices
{
    public class CvMarketDataService : DataServiceBase<CvMarketJob>, IDataService
    {


        public CvMarketDataService(
            CvMarketScrapeService scrapeService, CvMarketRepository repository,
            IMapper mapper, CompanyService companyService) : base(scrapeService, repository, companyService, mapper)
        {

        }
    }
}
