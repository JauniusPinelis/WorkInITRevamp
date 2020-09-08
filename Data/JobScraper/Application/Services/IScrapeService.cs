using Domain.Models;
using System.Collections.Generic;

namespace Application
{
	public interface IScrapeService
	{
		IEnumerable<JobUrl> ScrapeCvOnelineUrls();
		IEnumerable<JobUrl> ScrapeCvOnelineUrls(int pageLimit);
	}
}