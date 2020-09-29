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

		public int Insert(string name, byte[] imageData)
		{
			var company = new Company()
			{
				Name = name,
				ImageData = imageData
			};

			_context.Companies.Add(company);

			_context.SaveChanges();

			return company.Id;
		}
	}
}
