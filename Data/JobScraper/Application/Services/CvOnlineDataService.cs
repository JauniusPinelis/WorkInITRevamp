using AutoMapper;
using Domain.Models;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
	public class CvOnlineDataService : IDataService
	{
		private readonly CvOnlineScrapeService _scrapeService;
		private readonly CvOnlineRepostory _repository;
		private readonly IMapper _mapper;

		public CvOnlineDataService(CvOnlineScrapeService scrapeService, CvOnlineRepostory repository,
			IMapper mapper)
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
				var urls = _mapper.Map<IEnumerable<CvOnlineJob>>(urlDtos);
				_repository.InsertRange(urls);
			}
			else
			{
				var urlDtos = _scrapeService.ScrapeUrls();
				var urls = _mapper.Map<IEnumerable<CvOnlineJob>>(urlDtos);
				_repository.InsertRange(urls);
			}
		}

		public void ProcessSalaries()
		{

		}

		public void ProcessHtml()
		{

		}
	}
}
