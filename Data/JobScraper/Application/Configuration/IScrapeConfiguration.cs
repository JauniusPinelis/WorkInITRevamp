namespace Application.Configuration
{
	public interface IScrapeConfiguration
	{
		string Company { get; set; }
		string Name { get; set; }
		string Posting { get; set; }
		string Salary { get; set; }
		string Url { get; set; }

		string Info { get; set; }

		string LogoUrl { get; set; }
	}
}