using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
			var urls = _scrapeService.ScrapeCvOnelineUrls();

			_context.JobUrls.AddRange(urls);
			_context.SaveChanges();

		}

		public void ProcessSalaries()
		{
			_jobUrls = _
		}
	}
}
