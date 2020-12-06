﻿namespace Domain.Configuration
{
	public class CvOnlineConfiguration : IScrapeConfiguration
	{
		public string Posting { get; set; } = "div.cvo_module_offer";
		public string Name { get; set; } = "a[itemprop=title]";
		public string Salary { get; set; } = "span.salary-blue";
		public string Company { get; set; } = "a[itemprop=name]";
		public string Url { get; set; } = "";

		public string Info { get; set; } = "#wrapper";

		public string LogoUrl { get; set; } = ".cvo_module_offer_box img";
	}
}
