using Domain.Models;
using Infrastructure;
using System;
using System.Collections.Generic;
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
	}
}
