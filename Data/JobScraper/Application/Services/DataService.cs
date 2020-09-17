using Application.Helpers;
using Application.Services;
using Domain.Models;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
	public class DataService
	{
		private readonly UnitOfWork _unitOfWork;
		private readonly IScrapeService<CvOnlineJob> _cvOnlineScrapeService;
		private readonly IScrapeService<CvBankasJob> _cvBankasScrapeService;
		private readonly IScrapeService<CvMarketJob> _cvMarketScrapeService;

		public DataService(UnitOfWork unitOfWork, CvOnlineScrapeService cvOnlineScrapeService,
			CvBankasScrapeService cvBankasScrapeService, CvMarketScrapeService cvMarketScrapeService)
		{
			_unitOfWork = unitOfWork;
			_cvOnlineScrapeService = cvOnlineScrapeService;
			_cvBankasScrapeService = cvBankasScrapeService;
			_cvMarketScrapeService = cvMarketScrapeService;

		}

		public void ScrapeCvOnlineUrls()
		{
			if (_unitOfWork.CvOnline.GetAll().Any())
			{
				var urls = _cvOnlineScrapeService.ScrapeUrls(2);
				_unitOfWork.CvOnline.InsertRange(urls);
			}
			else
			{
				var urls = _cvOnlineScrapeService.ScrapeUrls();
				_unitOfWork.CvOnline.InsertRange(urls);
			}

		}

		public void ScrapeCvBankasUrls()
		{
			if (_unitOfWork.CvBankas.GetAll().Any())
			{
				var urls = _cvBankasScrapeService.ScrapeUrls(2);
				_unitOfWork.CvBankas.InsertRange(urls);
			}
			else
			{
				var urls = _cvBankasScrapeService.ScrapeUrls();
				_unitOfWork.CvBankas.InsertRange(urls);
			}
		}

		public void ScrapeCvMarketUrls()
		{
			if (_unitOfWork.CvMarket.GetAll().Any())
			{
				var urls = _cvMarketScrapeService.ScrapeUrls(2);
				_unitOfWork.CvMarket.InsertRange(urls);
			}
			else
			{
				var urls = _cvMarketScrapeService.ScrapeUrls();
				_unitOfWork.CvMarket.InsertRange(urls);
			}
		}

		public void ProcessSalaries()
		{
			var urls = _unitOfWork.Context.JobUrls
				.Where(u => u.SalaryMin == null && u.SalaryMax == null && (u.Salary != null || u.Salary != "")).ToList();

			foreach(var url in urls)
			{
				var (min, max) = SalaryHelpers.ExtractSalary(url.Salary);
				_unitOfWork.CvBankas.UpdateSalary(url.Id, min, max);
			}

		}
	}
}
