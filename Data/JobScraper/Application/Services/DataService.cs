using Application.DataServices;
using Application.Interfaces;
using AutoMapper;
using Domain.Extensions;
using Domain.Helpers;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Application
{
    public class DataService
	{
		private readonly UnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		private readonly IEnumerable<IDataService> _dataServices;

		public DataService(UnitOfWork unitOfWork, IMapper mapper, CvOnlineDataService cvOnlineDataService,
			CvBankasDataService cvBankasDataService, CvMarketDataService cvMarketDataService)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;

			_dataServices = new List<IDataService>()
			{
				cvOnlineDataService,
				cvBankasDataService,
				cvMarketDataService
			};

		}

		public void ScrapeJobs()
		{
			foreach(var services in _dataServices)
			{
				services.ScrapeJobs();
			}
		}

		public void ProcessCompanies()
		{
			_dataServices.ForEach(d => d.ProcessCompanies());
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

		internal void ProcessTags()
		{
			foreach (var service in _dataServices)
			{
				service.ProcessTags();
			}
		}

		public void ScrapeHtmls()
		{
			foreach(var service in _dataServices)
			{
				service.ScrapeHtmls();
			}
		}

		public void ProcessCompanyLogos() =>
			_dataServices.ForEach(d => d.ProcessCompanyLogos());
	}
}
