using Application.Helpers;
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
		private readonly ScrapeService _scrapeService;

		public DataService(JobUrlRepository jobUrlRepository, ScrapeService scrapeService)
		{
			_jobUrlRepository = jobUrlRepository;
			_scrapeService = scrapeService;

		}

		public void ScrapeUrls()
		{
			if (_jobUrlRepository.GetAll().Any())
			{
				var urls = _scrapeService.ScrapeCvOnelineUrls(2);
				_jobUrlRepository.InsertRange(urls);
			}
			else
			{
				var urls = _scrapeService.ScrapeCvOnelineUrls();
				_jobUrlRepository.InsertRange(urls);
			}

		}

		public void ProcessSalaries()
		{
			var urls = _jobUrlRepository.GetAll()
				.Where(u => u.SalaryMin == null && u.SalaryMax == null && u.Salary != "").ToList();

			foreach(var url in urls)
			{
				var (min, max) = SalaryHelpers.ExtractSalary(url.Salary);
				_jobUrlRepository.UpdateSalary(url.Id, min, max);
			}

		}
	}
}
