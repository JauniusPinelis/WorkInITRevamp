using Application.Services;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Application.DataServices
{
    public class CvBankasDataService : DataServiceBase<CvBankasJob>, IDataService
    {
        private readonly CvBankasScrapeService _scrapeService;
        private readonly CvBankasRepository _repository;
        private readonly IMapper _mapper;

        public CvBankasDataService(
            CvBankasScrapeService scrapeService, CvBankasRepository repository,
            IMapper mapper, CompanyService companyService
            ) : base(scrapeService, repository, companyService)
        {
            _scrapeService = scrapeService;
            _repository = repository;
            _mapper = mapper;
        }

        public void ScrapeJobs()
        {
            if (_repository.GetAll().Any())
            {
                var urlDtos = _scrapeService.ScrapeUrls(2);

                var urls = _mapper.Map<IEnumerable<CvBankasJob>>(urlDtos);
                _repository.InsertRange(urls);
            }
            else
            {
                var urlDtos = _scrapeService.ScrapeUrls();
                var urls = _mapper.Map<IEnumerable<CvBankasJob>>(urlDtos);
                _repository.InsertRange(urls);
            }
        }
    }
}
