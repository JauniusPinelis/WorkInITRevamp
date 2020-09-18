using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Tag : Entity
    {
		public string Name { get; set; }

		public ICollection<jobUrlTag> JobUrls { get; set; }
	}
}
