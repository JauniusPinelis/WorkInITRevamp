using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Base;
using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories
{
	public abstract class ReadRepositoryBase<T> : IReadRepository<T> where T : Entity
	{
		private readonly DataContext _context;
		private readonly IMapper _mapper;

		private DbSet<JobUrl> _entities;

		public ReadRepositoryBase(DataContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;

			_entities = _context.Set<JobUrl>();
		}

		public IEnumerable<T> GetAll()
		{
			return _entities.ProjectTo<T>(_mapper.ConfigurationProvider);
		}

		public JobUrl FindById(int id)
		{
			return
				_entities.SingleOrDefault(e => e.Id == id);
		}

		public IQueryable<Tag> GetAllTags()
		{
			return _context.Tags;
		}
	}
}
