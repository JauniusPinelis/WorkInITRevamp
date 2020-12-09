using Domain.Helpers;
using Domain.Models;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public class CompanyService
	{
		private readonly DataContext _context;

		public CompanyService(DataContext context)
		{
			_context = context;
		}

		public IEnumerable<Company> GetAll()
		{
			return _context.Companies;
		}

		public Company FindById(int id)
		{
			var company = _context.Companies.FirstOrDefault(c => c.Id == id);

			return company;
		}

		public bool DoesContain(string name)
		{
			return _context.Companies.Where(c => c.Name.ToLower().Contains(name.ToLower())).Any();
		}

		public int Insert(string name, string logoUrl)
		{
			var company = new Company()
			{
				Name = name,
				Logourl = logoUrl
			};

			_context.Companies.Add(company);

			_context.SaveChanges();

			return company.Id;
		}

		public Company GetByName(string companyName)
		{
			var company = _context.Companies.FirstOrDefault(c => c.Name == companyName);

			return company;
		}

		public void UpdateImage(int id, byte[] imageData, string url)
		{
			var imageExtension = UrlHelpers.ExtractFileExtension(url);

			var company = FindById(id);

			if (company != null)
			{
				company.ImageData = UrlHelpers.ConvertImageURLToBase64(imageData);
				company.ImageExtension = imageExtension;

				_context.SaveChanges();
			}
		}
	}
}
