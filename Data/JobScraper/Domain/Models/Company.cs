using Domain.Models.Base;
using System.Collections.Generic;

namespace Domain.Models
{
	public class Company : NamedEntity
	{
		public ICollection<JobUrl> Jobs { get; set; }

		public string ImageData { get; set; }

		public string ImageExtension { get; set; }

		public string Logourl { get; set; }
	}
}
