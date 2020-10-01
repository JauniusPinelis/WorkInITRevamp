using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
	public class JobUrl : NamedEntity
	{
		public string Url { get; set; }
		public string Salary { get; set; }

		public string CompanyName { get; set; }

		public int? SalaryMin { get; set; }
		public int? SalaryMax { get; set; }

		public string PortalName { get; set; }

		public DateTime Created { get; set; } = DateTime.Now;
		public DateTime? LastModified { get; set; }

		public ICollection<jobUrlTag> Tags { get; set; }

		public Company Company { get; set; }
	}
}
