using Application.Services;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Application.DataServices
{
    public class CvMarketDataService : DataServiceBase<CvMarketJob>, IDataService
    {
        private readonly CvMarketScrapeService _scrapeService;
        private readonly CvMarketRepository _repository;
        private readonly IMapper _mapper;

        public CvMarketDataService(
            CvMarketScrapeService scrapeService, CvMarketRepository repository,
            IMapper mapper, CompanyService companyService) : base(scrapeService, repository, companyService)
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
                var urls = _mapper.Map<IEnumerable<CvMarketJob>>(urlDtos);
                _repository.InsertRange(urls);
            }
            else
            {
                var urlDtos = _scrapeService.ScrapeUrls();
                var urls = _mapper.Map<IEnumerable<CvMarketJob>>(urlDtos);
                _repository.InsertRange(urls);
            }
        }
    }
}
