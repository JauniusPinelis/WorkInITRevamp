﻿using Application.Services;
using AutoMapper;
using Domain.Models;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataServices
{
    public class CvMarketDataService : IDataService
    {
		private readonly CvMarketScrapeService _scrapeService;
		private readonly CvMarketRepository _repository;
		private readonly IMapper _mapper;

		public CvMarketDataService(CvMarketScrapeService scrapeService, CvMarketRepository repository,
			IMapper mapper)
		{
			_scrapeService = scrapeService;
			_repository = repository;
			_mapper = mapper;
		}

		public void ScrapeHtmls()
		{
			throw new NotImplementedException();
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
