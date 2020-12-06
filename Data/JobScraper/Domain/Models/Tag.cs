using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
	public class Tag : NamedEntity
    {
		public ICollection<JobUrlTag> JobUrls { get; set; }
	}
}
