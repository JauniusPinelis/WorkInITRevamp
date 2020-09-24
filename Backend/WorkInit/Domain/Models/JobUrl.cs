using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public string PortalName { get; set; }

		public string Html { get; set; }

		public DateTime Created { get; set; } = DateTime.Now;
		public DateTime? LastModified { get; set; }

		public ICollection<jobUrlTag> Tags { get; set; }
	}
}
