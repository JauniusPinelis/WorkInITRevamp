using Application.Dtos;
using Domain.Models;
using System.Collections.Generic;
using System.Drawing;

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