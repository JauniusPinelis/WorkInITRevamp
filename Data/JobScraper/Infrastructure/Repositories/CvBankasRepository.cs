using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CvBankasRepository : JobRepositoryBase<CvBankasJob>
    {
		public CvBankasRepository(DataContext context, IMapper mapper) : base (context, mapper)
		{
		}
    }
}
