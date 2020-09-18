using AutoMapper;
using AutoMapper.QueryableExtensions;
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
		private readonly IMapper _mapper;

		private DbSet<JobUrl> entities;

		public ReadRepositoryBase(DataContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;

			entities = _context.Set<JobUrl>();
		}

		public IEnumerable<T> GetAll()
		{
			return entities.ProjectTo<T>(_mapper.ConfigurationProvider);
		}

		public T FindById(int id)
		{
			return 
				_mapper.Map<T>(entities.SingleOrDefault(e => e.Id == id));
		}
	}
}
