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
			_dataService.ScrapeCvOnlineUrls();
			_dataService.ProcessSalaries();
		}
	}
}
