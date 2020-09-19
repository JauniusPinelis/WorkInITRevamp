using Application.Helpers;
using Application.Services;
using AutoMapper;
using Domain.Models;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
	public class DataService
	{
		private readonly UnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		private readonly IEnumerable<IScrapeService> _scrapeServices;

		public DataService(UnitOfWork unitOfWork, IMapper mapper, CvOnlineScrapeService cvOnlineScrapeService,
			CvBankasScrapeService cvBankasScrapeService, CvMarketScrapeService cvMarketScrapeService)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;

			_scrapeServices = new List<IScrapeService>()
			{
				cvOnlineScrapeService,
				cvBankasScrapeService,
				cvMarketScrapeService
			};

		}

		public void ScrapeUrls()
		{
			foreach(var services in _scrapeServices)
			{

			}
		}

		public void ScrapeCvOnlineUrls()
		{
			if (_unitOfWork.CvOnline.GetAll().Any())
			{
				var urlDtos = _cvOnlineScrapeService.ScrapeUrls(2);
				var urls = _mapper.Map<IEnumerable<CvOnlineJob>>(urlDtos);
				_unitOfWork.CvOnline.InsertRange(urls);
			}
			else
			{
				var urlDtos = _cvOnlineScrapeService.ScrapeUrls();
				var urls = _mapper.Map<IEnumerable<CvOnlineJob>>(urlDtos);
				_unitOfWork.CvOnline.InsertRange(urls);
			}

		}

		public void ScrapeCvBankasUrls()
		{
			if (_unitOfWork.CvBankas.GetAll().Any())
			{
				var urlDtos = _cvBankasScrapeService.ScrapeUrls(2);
				var urls = _mapper.Map<IEnumerable<CvBankasJob>>(urlDtos);
				_unitOfWork.CvBankas.InsertRange(urls);
			}
			else
			{
				var urlDtos = _cvBankasScrapeService.ScrapeUrls();
				var urls = _mapper.Map<IEnumerable<CvBankasJob>>(urlDtos);
				_unitOfWork.CvBankas.InsertRange(urls);
			}
		}

		public void ScrapeCvMarketUrls()
		{
			if (_unitOfWork.CvMarket.GetAll().Any())
			{
				var urlDtos = _cvMarketScrapeService.ScrapeUrls(2);
				var urls = _mapper.Map<IEnumerable<CvMarketJob>>(urlDtos);
				_unitOfWork.CvMarket.InsertRange(urls);
			}
			else
			{
				var urlDtos = _cvMarketScrapeService.ScrapeUrls();
				var urls = _mapper.Map<IEnumerable<CvMarketJob>>(urlDtos);
				_unitOfWork.CvMarket.InsertRange(urls);
			}
		}

		public void ProcessSalaries()
		{
			var urls = _unitOfWork.Context.JobUrls
				.Where(u => u.SalaryMin == null && u.SalaryMax == null && (u.Salary != null || u.Salary != "")).ToList();

			foreach(var url in urls)
			{
				var (min, max) = SalaryHelpers.ExtractSalary(url.Salary);
				_unitOfWork.CvBankas.UpdateSalary(url.Id, min, max);
			}

		}
	}
}
