using Application.Interfaces;
using Domain.Models;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataServices
{
    public abstract class DataServiceBase<T> where T : JobUrl
    {
		private readonly IScrapeService _scrapeService;
		private readonly IRepository<T> _repository;
		
		public DataServiceBase(IScrapeService scrapeService, IRepository<T> repository)
		{
			_repository = repository;
			_scrapeService = scrapeService;
		}

		public void ScrapeHtmls()
		{
			var jobs = _repository.GetAll()
				.Where(j => !String.IsNullOrEmpty(j.Url) && String.IsNullOrEmpty(j.Html)).ToList();

			foreach (var job in jobs)
			{
				var html = _scrapeService.ScrapeInfo(job.Url);

				_repository.UpdateHtml(job.Id, html);
			}
		}
	}
}
