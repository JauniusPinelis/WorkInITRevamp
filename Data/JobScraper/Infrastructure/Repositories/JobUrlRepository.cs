using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories
{
	public class JobUrlRepository
	{
		private readonly DataContext _context;

		public JobUrlRepository(DataContext context)
		{
			_context = context;
		}

		public void Insert(JobUrl jobUrl)
		{
			var exists = _context.JobUrls.Any(
				j => j.Title == jobUrl.Title
			&& j.Company == jobUrl.Company
			&& j.Salary == jobUrl.Salary);

			if (!exists)
			{
				_context.JobUrls.Add(jobUrl);
			}

			_context.SaveChanges();
		}

		public void InsertRange(IEnumerable<JobUrl> jobUrls)
		{
			foreach(var jobUrl in jobUrls)
			{

			}
		}
	}
}
