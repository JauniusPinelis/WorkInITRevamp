namespace Domain.Configuration
{
	public class CvMarketConfiguration : IScrapeConfiguration
	{
		public string Posting { get; set; } = "tr.f_job_row2";
		public string Company { get; set; } = ".f_job_company";
		public string Salary { get; set; } = "span.f_job_salary";
		public string Name { get; set; } = "a.f_job_title";
		public string Url { get; set; } = "a.f_job_title";

		public string Info { get; set; } = ".job-offer";

		public string LogoUrl { get; set; } = "span.f_firm_logo_wrapper img";

	}
}
