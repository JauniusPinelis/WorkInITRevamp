﻿namespace Application.Services
{
	public interface IDataService
	{
		void ScrapeJobs();
		void ScrapeHtmls();
		void ProcessTags();
		void ProcessCompanies();

		void ProcessCompanyLogos();
	}
}