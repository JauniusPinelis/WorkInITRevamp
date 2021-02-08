using Application.Services;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;

namespace Application.DataServices
{
    public class CvBankasDataService : DataServiceBase<CvBankasJob>, IDataService
    {

        public CvBankasDataService(
            CvBankasScrapeService scrapeService, CvBankasRepository repository,
            IMapper mapper, CompanyService companyService
            ) : base(scrapeService, repository, companyService, mapper)
        {

        }
    }
}
