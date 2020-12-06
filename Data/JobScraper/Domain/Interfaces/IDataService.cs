namespace Domain.Interfaces
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