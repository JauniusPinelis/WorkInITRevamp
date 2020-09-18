using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UnitOfWork
    {
		public readonly CvBankasRepository CvBankas;
		public readonly CvOnlineRepostory CvOnline;
		public readonly CvMarketRepository CvMarket;
		public DataContext Context;

		public UnitOfWork(DataContext context, IMapper mapper)
		{
			Context = context;
			CvBankas = new CvBankasRepository(context, mapper);
			CvOnline = new CvOnlineRepostory(context, mapper);
			CvMarket = new CvMarketRepository(context, mapper);
		}
    }
}
