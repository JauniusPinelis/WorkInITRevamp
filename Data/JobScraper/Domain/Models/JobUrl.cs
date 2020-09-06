using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
	public class JobUrl : Entity
	{

		public string Url { get; set; }
		public string Title { get; set; }
		public string Salary { get; set; }

		public string Company { get; set; }

		public int? SalaryMin { get; set; }
		public int? SalaryMax { get; set; }
	}
}
