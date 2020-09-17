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

		public UnitOfWork(DataContext context)
		{
			CvBankas = new CvBankasRepository(context);
			CvOnline = new CvOnlineRepostory(context);
			CvMarket = new CvMarketRepository(context);
		}
    }
}
