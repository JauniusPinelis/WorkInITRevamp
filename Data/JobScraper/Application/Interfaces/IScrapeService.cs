using Domain.Models;
using System.Collections.Generic;

namespace Application.Interfaces
{
	public interface IScrapeService
	{
		IEnumerable<JobUrl> ScrapeUrls();
		IEnumerable<JobUrl> ScrapeUrls(int pageLimit);

		string ScrapeInfo(string url);
	}
}