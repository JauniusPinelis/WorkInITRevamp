using Application;
using Application.Configuration;
using Application.DataServices;
using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Domain;
using HtmlAgilityPack;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTests
{
    public abstract class TestBase
    {
		protected readonly IScraper _cvBankasScraper;
		protected readonly IScraper _cvOnlineScraper;
		protected readonly IScraper _cvMarketScraper;

		private readonly IMapper _mapper;

		protected readonly CvBankasScrapeService _cvBankasScrapeService;
		protected readonly CvOnlineScrapeService _cvOnlineScrapeService;
		protected readonly CvMarketScrapeService _cvMarketScrapeService;

		protected readonly CvOnlineDataService _cvOnlineDataService;
		protected readonly CvBankasDataService _cvBankasDataService;
		protected readonly CvMarketDataService _cvMarketDataService;

		protected readonly CvBankasRepository _cvBankasRepository;
		protected readonly CvOnlineRepostory _cvOnlineRepostory;
		protected readonly CvMarketRepository _cvMarketRepository;

		protected readonly UnitOfWork _unitOfWork;

		protected readonly DataService _dataService;

		private const string cvOnlineFilePath = "\\Data\\CvOnline.txt";
		private const string cvBankasFilePath = "\\Data\\CvBankas.txt";
		private const string CvMarketFilePath = "\\Data\\CvMarket.txt";

		public TestBase()
		{

			_cvOnlineScraper = SetupMockScraper(cvOnlineFilePath);
			_cvBankasScraper = SetupMockScraper(cvBankasFilePath);
			_cvMarketScraper = SetupMockScraper(CvMarketFilePath);


			_cvOnlineScrapeService = new CvOnlineScrapeService(_cvOnlineScraper, new CvOnlineConfiguration());
			_cvBankasScrapeService = new CvBankasScrapeService(_cvBankasScraper, new CvBankasConfiguration());
			_cvMarketScrapeService = new CvMarketScrapeService(_cvMarketScraper, new CvMarketConfiguration());

			var options = new DbContextOptionsBuilder<DataContext>()
			.UseInMemoryDatabase("TestDb")
			.Options;

			var context = new DataContext(options);

			var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());

			var _mapper = mapperConfig.CreateMapper();

			_cvOnlineRepostory = new CvOnlineRepostory(context, _mapper);
			_cvBankasRepository = new CvBankasRepository(context, _mapper);
			_cvMarketRepository = new CvMarketRepository(context, _mapper);

			_cvOnlineDataService = new CvOnlineDataService(
				_cvOnlineScrapeService, _cvOnlineRepostory, _mapper);

			_cvBankasDataService = new CvBankasDataService(
			_cvBankasScrapeService, _cvBankasRepository, _mapper);

			_cvMarketDataService = new CvMarketDataService(
			_cvMarketScrapeService, _cvMarketRepository, _mapper);


			_unitOfWork = new UnitOfWork(context, _mapper);

			_dataService = new DataService(_unitOfWork, _mapper, 
				_cvOnlineDataService, _cvBankasDataService,_cvMarketDataService
				);
		}

		private IScraper SetupMockScraper(string filePath)
		{
			var scraperMock = new Mock<IScraper>();

			var path = Directory.GetCurrentDirectory() + filePath;

			var decodedData = WebUtility.HtmlDecode(File.ReadAllText(path));

			HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml(decodedData);
			HtmlNodeCollection nodes = doc.DocumentNode.ChildNodes;

			scraperMock.Setup(s => s.GetHtml(It.IsAny<string>())).Returns(nodes.First());

			return scraperMock.Object;
		}
    }
}
