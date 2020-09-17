using Domain.Models;
using System.Collections.Generic;

namespace Application
{
	public interface IScrapeService<T> where T : JobUrl
	{
		IEnumerable<T> ScrapeUrls();
		IEnumerable<T> ScrapeUrls(int pageLimit);
	}
}