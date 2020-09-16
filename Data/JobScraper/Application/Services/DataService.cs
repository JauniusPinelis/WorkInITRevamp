using Application.Helpers;
using Application.Services;
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
		private readonly JobUrlRepository _jobUrlRepository;
		private readonly IScrapeService _cvOnlineScrapeService;
		private readonly IScrapeService _cvBankasScrapeService;
		private readonly IScrapeService _cvMarketScrapeService;

		public DataService(JobUrlRepository jobUrlRepository, CvOnlineScrapeService cvOnlineScrapeService,
			CvBankasScrapeService cvBankasScrapeService, CvMarketScrapeService cvMarketScrapeService)
		{
			_jobUrlRepository = jobUrlRepository;
			_cvOnlineScrapeService = cvOnlineScrapeService;
			_cvBankasScrapeService = cvBankasScrapeService;
			_cvMarketScrapeService = cvMarketScrapeService;

		}

		public void ScrapeCvOnlineUrls()
		{
			if (_jobUrlRepository.GetAll().Any())
			{
				var urls = _cvOnlineScrapeService.ScrapeUrls(2);
				_jobUrlRepository.InsertRange(urls);
			}
			else
			{
				var urls = _cvOnlineScrapeService.ScrapeUrls();
				_jobUrlRepository.InsertRange(urls);
			}

		}

		public void ScrapeCvBankasUrls()
		{
			if (_jobUrlRepository.GetAll().Any())
			{
				var urls = _cvBankasScrapeService.ScrapeUrls(2);
				_jobUrlRepository.InsertRange(urls);
			}
			else
			{
				var urls = _cvBankasScrapeService.ScrapeUrls();
				_jobUrlRepository.InsertRange(urls);
			}
		}

		public void ScrapeCvMarketUrls()
		{
			if (_jobUrlRepository.GetAll().Any())
			{
				var urls = _cvMarketScrapeService.ScrapeUrls(2);
				_jobUrlRepository.InsertRange(urls);
			}
			else
			{
				var urls = _cvMarketScrapeService.ScrapeUrls();
				_jobUrlRepository.InsertRange(urls);
			}
		}

		public void ProcessSalaries()
		{
			var urls = _jobUrlRepository.GetAll()
				.Where(u => u.SalaryMin == null && u.SalaryMax == null && (u.Salary != null || u.Salary != "")).ToList();

			foreach(var url in urls)
			{
				var (min, max) = SalaryHelpers.ExtractSalary(url.Salary);
				_jobUrlRepository.UpdateSalary(url.Id, min, max);
			}

		}
	}
}
