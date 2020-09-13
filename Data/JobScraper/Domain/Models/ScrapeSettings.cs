using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
	public class ScrapeSettings
	{
		public string Posting { get; set; }
		public string Name { get; set; }
		public string Salary { get; set; }
		public string Company { get; set; }

		public string Url { get; set; }
	}
}
