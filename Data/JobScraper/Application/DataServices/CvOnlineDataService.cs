using Application.Services;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;

namespace Application.DataServices
{
    public class CvOnlineDataService : DataServiceBase<CvOnlineJob>, IDataService
    {
        public CvOnlineDataService(
            CvOnlineScrapeService scrapeService, CvOnlineRepostory repository,
            IMapper mapper, CompanyService companyService) : base(scrapeService, repository, companyService, mapper)
        {

        }
    }
}
