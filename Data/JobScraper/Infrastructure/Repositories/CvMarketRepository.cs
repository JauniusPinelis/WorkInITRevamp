﻿using AutoMapper;
using Domain.Models;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CvMarketRepository : JobRepositoryBase<CvMarketJob>, IRepository<CvMarketJob>
	{
		public CvMarketRepository(DataContext context, IMapper mapper) : base (context, mapper)
		{

		}
    }
}
