using Domain.Base;

namespace Domain.Models
{
	public class JobUrlTag : Entity
	{
		public int JobUrlId { get; set; }
		public JobUrl JobUrl { get; set; }
		public int TagId { get; set; }
		public Tag Tag { get; set; }
	}
}
