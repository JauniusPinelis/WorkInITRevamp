using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CvOnlineRepostory : JobRepositoryBase<CvOnlineJob>
    {
		public CvOnlineRepostory(DataContext context, IMapper _mapper) : base(context, _mapper)
		{

		}
    }
}
