using AutoMapper;
using Domain.Models;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CvOnlineRepostory : JobRepositoryBase<CvOnlineJob>, IRepository<CvOnlineJob>
	{
		public CvOnlineRepostory(DataContext context, IMapper _mapper) : base(context, _mapper)
		{

		}
    }
}
