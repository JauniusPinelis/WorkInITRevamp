using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
	public class JobScraperRunner
	{
		private readonly DataService _dataService;

		public JobScraperRunner(DataService dataService)
		{
			_dataService = dataService;
		}
		public void Run()
		{
			//_dataService.ScrapeJobs();
			//_dataService.ProcessSalaries();
			//_dataService.ProcessCompanies();
			_dataService.ProcessCompanyLogos();
			//_dataService.ScrapeHtmls();
			//_dataService.ProcessTags();
		}
	}
}
