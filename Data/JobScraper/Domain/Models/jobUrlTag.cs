using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
	public class jobUrlTag : Entity
    {
        public int JobUrlId { get; set; }
		public JobUrl JobUrl { get; set; }
		public int TagId { get; set; }
		public Tag Tag { get; set; }
	}
}
