using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ScrapeServiceBase
    {
		private readonly IScraper _scraper;

		public ScrapeServiceBase(IScraper scraper)
		{
			_scraper = scraper;
		}

		public Image ScrapeLogo(string url)
		{
			return _scraper.GetImage(url);
		}
    }
}
