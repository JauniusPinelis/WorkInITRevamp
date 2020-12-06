using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
	public abstract class JobRepositoryBase<T> : ReadRepositoryBase<T>, IRepository<T> where T : JobUrl
	{
		private readonly DataContext _context;

		private DbSet<T> _entities;

		public JobRepositoryBase(DataContext context, IMapper mapper) : base(context, mapper)
		{
			_context = context;

			_entities = _context.Set<T>();
		}

		public void Insert(T entity)
		{
			var exists = _context.JobUrls.Any(
				j => j.Name == entity.Name
			&& j.CompanyName == entity.CompanyName
			&& j.Salary == entity.Salary);

			if (!exists)
			{
				_context.JobUrls.Add(entity);
			}

			_context.SaveChanges();
		}

		public void InsertRange(IEnumerable<T> entities)
		{
			foreach (var entity in entities)
			{
				Insert(entity);
			}
		}

		public void UpdateSalary(int id, int? min, int? max)
		{
			var jobEntity = FindById(id);
			jobEntity.SalaryMin = min;
			jobEntity.SalaryMax = max;

			_context.SaveChanges();
		}

		public void UpdateHtml(int id, string html)
		{
			var jobEntity = FindById(id);
			jobEntity.Html = html;

			_context.SaveChanges();
		}

		public void UpdateTags(int id, IEnumerable<Tag> tags)
		{
			var JobEntity = FindById(id);

			//Removing previous tags
			var tagsToRemove = _context.JobUrlTags.Where(j => j.JobUrlId == id);
			_context.RemoveRange(tagsToRemove);
			_context.SaveChanges();

			// Adding new ones

			foreach(var tag in tags)
			{
				_context.JobUrlTags.Add(new jobUrlTag()
				{
					JobUrl = JobEntity,
					Tag = tag
				});
			}

			_context.SaveChanges();
		}

		public void UpdateCompany(int id, int companyId)
		{
			var job = FindById(id);

			job.CompanyId = companyId;

			_context.SaveChanges();
		}
	}
}
