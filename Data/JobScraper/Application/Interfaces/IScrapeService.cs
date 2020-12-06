using Application.Dtos;
using System.Collections.Generic;

namespace Application.Interfaces
{
	public interface IScrapeService
	{
		IEnumerable<JobDto> ScrapeUrls();
		IEnumerable<JobDto> ScrapeUrls(int pageLimit);

		string ScrapeInfo(string url);

		byte[] ScrapeLogo(string url);
	}
}