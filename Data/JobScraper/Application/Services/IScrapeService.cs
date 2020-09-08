using Domain.Models;
using System.Collections.Generic;

namespace Application
{
	public interface IScrapeService
	{
		IEnumerable<JobUrl> ScrapeUrls();
		IEnumerable<JobUrl> ScrapeUrls(int pageLimit);
	}
}