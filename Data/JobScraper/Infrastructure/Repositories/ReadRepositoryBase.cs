using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories
{
	public abstract class ReadRepositoryBase<T> where T : Entity
	{
		private readonly DataContext _context;

		private DbSet<T> entities;

		public ReadRepositoryBase(DataContext context)
		{
			_context = context;
			entities = _context.Set<T>();
		}

		public IQueryable<T> GetAll()
		{
			return entities;
		}

		public T FindById(int id)
		{
			return entities.SingleOrDefault(e => e.Id == id);
		}
	}
}
