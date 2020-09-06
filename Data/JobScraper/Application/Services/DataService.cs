using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
	public class DataService
	{
		private readonly DbContext _context;
		private readonly ScrapeService _scrapeService;

		public DataService(DataContext context, ScrapeService scrapeService)
		{
			_context = context;
			_scrapeService = scrapeService;
		}

		public void ScrapeUrls()
		{
			_scrapeService.ScrapeCvOnelineUrls();
		}
	}
}
