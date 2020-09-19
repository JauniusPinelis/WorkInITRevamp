using System.Collections.Generic;

namespace Domain.Models
{
	public interface IJob
	{
		string Company { get; set; }
		string Html { get; set; }
		string PortalName { get; set; }
		string Salary { get; set; }
		int? SalaryMax { get; set; }
		int? SalaryMin { get; set; }
		ICollection<jobUrlTag> Tags { get; set; }
		string Title { get; set; }
		string Url { get; set; }
	}
}